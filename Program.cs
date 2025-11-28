using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=app.db"));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
var app = builder.Build();

//get LISTAR USUÁRIOS
app.MapGet("/usuarios", async (IUsuarioService service, CancellationToken ct) =>
{
    var usuarios = await service.ListarAsync(ct);
    return Results.Ok(usuarios);
});

//get OBTER USUÁRIO POR ID
app.MapGet("/usuarios/{id}", async (int id, IUsuarioService service, CancellationToken ct) =>
{
    var usuario = await service.ObterAsync(id, ct);
    return usuario != null ? Results.Ok(usuario) : Results.NotFound();
});

//post CRIAR USUÁRIO
app.MapPost("/usuarios", async (UsuarioCreateDto dto, IUsuarioService service, CancellationToken ct) =>
{
    var usuario = await service.CriarAsync(dto, ct);

    return Results.Created($"/usuarios/{usuario.Id}", usuario);
});

//put ATUALIZA USUÁRIO
app.MapPut("/usuarios/{id:int}", async (int id, UsuarioUpdateDto dto, IUsuarioService service, CancellationToken ct) =>
{
   var usuarioAtualizado = await service.AtualizarAsync(id, dto, ct);
   if (usuarioAtualizado is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(usuarioAtualizado);
});

//delete DELETAR USUÁRIO (SOFT DELETE)
app.MapDelete("/usuarios/{id}", async (int id, IUsuarioService service, CancellationToken ct) =>
{
   var usuarioRemovido = await service.RemoverAsync(id, ct);
   if (!usuarioRemovido)
    {
        return Results.NotFound();
    }
    return Results.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.Run();
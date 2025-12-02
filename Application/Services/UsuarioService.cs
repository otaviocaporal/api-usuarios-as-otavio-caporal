using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;

    public UsuarioService(IUsuarioRepository repo)
    {
        _repo = repo;
    }

    async Task<IEnumerable<UsuarioReadDto>> IUsuarioService.ListarAsync(CancellationToken ct = default)
    {
         var usuarios = await _repo.GetAllAsync(ct);

        return usuarios.Select(u => new UsuarioReadDto(
            u.Id,
            u.Nome,
            u.Email,
            u.DataNascimento,
            u.Telefone,
            u.Ativo,
            u.DataCriacao
        ));
    }

    public async Task<UsuarioReadDto?> ObterAsync(int id, CancellationToken ct = default)
    {
        if (id <= 0)
        {
            throw new ArgumentException("O ID do usuário deve ser maior que zero.", nameof(id));
        }
        var usuario = await _repo.GetByIdAsync(id, ct);
        if (usuario == null)
        {
            throw new KeyNotFoundException("Usuário não encontrado");
        }
        var usuarioDTO = MappingExtensions.ToReadDto(usuario);
        return usuarioDTO;
    }

    public async Task<UsuarioReadDto> CriarAsync(UsuarioCreateDto dto, CancellationToken ct = default)
    {
        var emailExiste = await _repo.EmailExistsAsync(dto.Email, ct);

        if (emailExiste)
        {
            throw new InvalidOperationException("O email informado já está cadastrado.");
        }

        var usuario = UsuarioFactory.Criar(
            nome: dto.Nome,
            email: dto.Email,
            senha: dto.Senha,
            dataNascimento: dto.DataNascimento,
            telefone: dto.Telefone
        );

        await _repo.AddAsync(usuario, ct);
        await _repo.SaveChangesAsync(ct);

        return usuario.ToReadDto();
    }

    public async Task<UsuarioReadDto> AtualizarAsync(int id, UsuarioUpdateDto dto, CancellationToken ct = default)
    {
        var usuario = await _repo.GetByIdAsync(id, ct);
        if (usuario == null)
        {
            throw new KeyNotFoundException("O usuário informado não existe.");
        }
        usuario.Nome = dto.Nome;
        usuario.Email = dto.Email;
        usuario.DataNascimento = dto.DataNascimento;
        usuario.Telefone = dto.Telefone;
        usuario.Ativo = dto.Ativo;
        usuario.DataAtualizacao = DateTime.UtcNow;
        await _repo.UpdateAsync(usuario, ct);
        await _repo.SaveChangesAsync(ct);

        return usuario.ToReadDto();
    }

    public async Task<bool> RemoverAsync(int id, CancellationToken ct = default)
    {
        var usuario = await _repo.GetByIdAsync(id, ct);
        if (usuario == null)
        {
            throw new KeyNotFoundException("O usuário informado não existe.");
        }
        usuario.Ativo = false;
        usuario.DataAtualizacao = DateTime.UtcNow;

        await _repo.UpdateAsync(usuario, ct);
        await _repo.SaveChangesAsync(ct);

        return true;
    }

    public async Task<bool> EmailJaCadastradoAsync(string email, CancellationToken ct = default)
    {
        return await _repo.EmailExistsAsync(email.ToLower(), ct);
    }
}
using Domain.Entities;

namespace Application.Services;

public static class UsuarioFactory
{
    public static Usuario Criar(string nome, string  email, string  senha, DateTime  dataNascimento, string? telefone )
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome é obrigatório.", nameof(nome));
        }
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("O email é obrigatório.", nameof(email));
        }
        if (string.IsNullOrWhiteSpace(senha))
        {
            throw new ArgumentException("A senha é obrigatória.", nameof(senha));
        }
        if (dataNascimento == DateTime.MinValue)
        {
            throw new ArgumentException("A data de nascimento é inválida.", nameof(dataNascimento));
        }
        Usuario usuarioCriado = new Usuario();
        usuarioCriado.Nome = nome;
        usuarioCriado.Email = email.ToLower();
        usuarioCriado.Senha = senha;
        usuarioCriado.DataNascimento = dataNascimento;
        usuarioCriado.Telefone = telefone;
        usuarioCriado.Ativo = true;
        usuarioCriado.DataCriacao = DateTime.UtcNow;
        return usuarioCriado;
    }
}
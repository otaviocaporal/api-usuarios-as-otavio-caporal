using System.ComponentModel.DataAnnotations;
using Application.Interfaces;

namespace Domain.Entities
{
    public  class  Usuario

    {
    [Key]
    public  int Id { get; set; } // PK, Auto-increment

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public  string Nome { get; set; } = string.Empty; // Obrigatório, 3-100 caracteres

    [Required]
    [EmailAddress]
    public  string Email { get; set; } = string.Empty; // Obrigatório, formato válido, único

    [Required]
    [MinLength(6)]
    public  string Senha { get; set; } = string.Empty;// Obrigatório, min 6 caracteres

    [Required]
    public  DateTime DataNascimento { get; set; } // Obrigatório, idade >= 18 anos

    [Phone]
    [MaxLength(15)]
    public  string? Telefone { get; set; } // Opcional, formato (XX) XXXXX-XXXX

    [Required]
    public  bool Ativo { get; set; } // Obrigatório, default true

    [Required]
    public  DateTime DataCriacao { get; set; } = DateTime.Now; // Obrigatório, preenchido automaticamente

    public  DateTime? DataAtualizacao { get; set; } // Opcional, atualizado automaticamente

    }
}
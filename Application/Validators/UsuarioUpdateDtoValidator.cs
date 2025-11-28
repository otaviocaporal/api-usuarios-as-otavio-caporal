using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UsuarioUpdateValidator : AbstractValidator<UsuarioUpdateDto>
    {
        public UsuarioUpdateValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email informado é inválido.");

            RuleFor(u => u.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(SerMaiorDeIdade)
                .WithMessage("O usuário deve ter pelo menos 18 anos.");

            RuleFor(u => u.Telefone)
                .Matches(@"^\+55\s\(\d{2}\)\s9\d{4}-\d{4}$")
                .When(u => !string.IsNullOrWhiteSpace(u.Telefone))
                .WithMessage("O telefone deve estar no formato +55 (XX) 9XXXX-XXXX.");

            RuleFor(u => u.Ativo)
                .NotNull().WithMessage("O campo 'Ativo' é obrigatório.");
        }

        private bool SerMaiorDeIdade(DateTime data)
        {
            var idade = DateTime.Today.Year - data.Year;

            if (data.Date > DateTime.Today.AddYears(-idade))
                idade--;

            return idade >= 18;
        }
    }
}

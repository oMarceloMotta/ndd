using System;
using System.Threading;
using System.Threading.Tasks;
using application.Features.Clientes.Commands.CreateCliente;
using domain.Repository;
using FluentValidation;

namespace application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        public UpdateClienteCommandValidator(IClienteRepository clienteReposity)
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} deve ter no máximo 100 caracteres");
            RuleFor(p => p.Sexo)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull();
            RuleFor(p => p.Telefone)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull()
                .MaximumLength(11).WithMessage("{PropertyName} deve ter no máximo 11 dígitos")
                .MinimumLength(10).WithMessage("{PropertyName} deve conter pelo menos 10 dígitos");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull()
                .EmailAddress().WithMessage("O formato do {PropertyName} é inválido");
            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull();

            _clienteRepository = clienteReposity;
        }

 
    }
}

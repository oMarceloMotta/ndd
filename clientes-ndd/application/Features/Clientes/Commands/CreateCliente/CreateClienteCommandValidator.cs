using System;
using System.Threading;
using System.Threading.Tasks;
using domain.Repository;
using FluentValidation;

namespace application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        public CreateClienteCommandValidator(IClienteRepository clienteRepository)
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
                .MaximumLength(12).WithMessage("{PropertyName} deve ter no máximo 11 dígitos")
                .MinimumLength(10).WithMessage("{PropertyName} deve conter pelo menos 10 dígitos");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull()
                .EmailAddress().WithMessage("O formato do {PropertyName} é inválido");
            RuleFor(p => p.DataNascimento)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull();

            RuleFor(p => p)
                .MustAsync(ClienteCPFUnique).WithMessage("Este CPF já existe");

            _clienteRepository = clienteRepository;
        }

        private Task<bool> ClienteCPFUnique(CreateClienteCommand command, CancellationToken token)
        {
            return _clienteRepository.IsClienteCPFUnique(command.CPF);
        }
    }
}

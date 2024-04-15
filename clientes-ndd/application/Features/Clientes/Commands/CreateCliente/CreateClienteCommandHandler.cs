using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using application.Exceptions;
using AutoMapper;
using domain.Repository;
using MediatR;
using domain.Entity;

namespace application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository) {
            this._clienteRepository = clienteRepository;
        }

        public async Task<Guid> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateClienteCommandValidator(_clienteRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any()) 
                throw new BadRequestException("Cliente inválido", validationResult);

            var newCliente = new Cliente
            {
                Nome = request.Nome,
                CPF = request.CPF,
                Sexo = request.Sexo,
                Telefone = request.Telefone,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Observacao = request.Observacao
            }; await _clienteRepository.CreateAsync(newCliente);
            return newCliente.Id;
        }
    }
}

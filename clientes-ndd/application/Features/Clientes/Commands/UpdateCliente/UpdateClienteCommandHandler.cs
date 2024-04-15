using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using application.Exceptions;
using AutoMapper;
using domain.Entity;
using domain.Repository;
using MediatR;

namespace application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteRepository _repository;

        public UpdateClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClienteCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Cliente inválido", validationResult);

            var updateCliente = new Cliente
            {
                Id = request.Id, 
                Nome = request.Nome,
                CPF = request.CPF,
                Sexo = request.Sexo,
                Telefone = request.Telefone,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Observacao = request.Observacao
            };
            await _repository.UpdateAsync(updateCliente);

            return Unit.Value;
        }
    }
}

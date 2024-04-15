using System;
using System.Threading;
using System.Threading.Tasks;
using application.Exceptions;
using application.Features.Clientes.Commands.UpdateCliente;
using AutoMapper;
using domain.Entity;
using domain.Repository;
using MediatR;

namespace application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Unit>
    {
        private readonly IClienteRepository _repository;

        public DeleteClienteCommandHandler(IClienteRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteDelete = await _repository.GetByIdAsync(request.Id);
            if (clienteDelete == null)
                throw new NotFoundException(nameof(Cliente), request.Id);

            await _repository.DeleteAsync(clienteDelete);
            return Unit.Value;
            
        }
    }
}

using System;
using MediatR;

namespace application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}

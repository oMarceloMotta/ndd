using System.Collections.Generic;

using MediatR;

namespace application.Features.Clientes.Queries.GetAllCliente
{
    public class GetClienteQuery : IRequest<List<ClienteDto>> {
    }
}

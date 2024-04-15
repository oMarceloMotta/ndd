using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using domain.Repository;
using MediatR;

namespace application.Features.Clientes.Queries.GetClienteDetails
{
    public class GetClienteDetailsQuery : IRequest<ClienteDetailsDto>
    {
        public GetClienteDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

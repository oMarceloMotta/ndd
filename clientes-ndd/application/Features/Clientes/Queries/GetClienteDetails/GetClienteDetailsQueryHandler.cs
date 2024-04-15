using System;
using System.Threading;
using System.Threading.Tasks;
using application.Exceptions;
using AutoMapper;
using domain.Entity;
using domain.Repository;
using MediatR;

namespace application.Features.Clientes.Queries.GetClienteDetails
{
    public class GetClienteDetailsQueryHandler : IRequestHandler<GetClienteDetailsQuery, ClienteDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public GetClienteDetailsQueryHandler(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }


        public async Task<ClienteDetailsDto> Handle(GetClienteDetailsQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            if (cliente == null)
                throw new NotFoundException(nameof(Cliente), request.Id);

            ClienteDetailsDto data = _mapper.Map<ClienteDetailsDto>(cliente);

            return data;
        }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using domain.Repository;
using MediatR;

namespace application.Features.Clientes.Queries.GetAllCliente
{
    public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, List<ClienteDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public GetClienteQueryHandler(IMapper mapper, IClienteRepository clienteRepository)
        {
            this._mapper = mapper;
            this._clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteDto>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var cliente = await  _clienteRepository.GetAsync();
            List<ClienteDto> data = _mapper.Map<List<ClienteDto>>(cliente);

            return data;
        }
    }
}

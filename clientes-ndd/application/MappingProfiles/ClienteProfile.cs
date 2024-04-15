using System;
using application.Features.Clientes.Commands.CreateCliente;
using application.Features.Clientes.Commands.UpdateCliente;
using application.Features.Clientes.Queries.GetAllCliente;
using application.Features.Clientes.Queries.GetClienteDetails;
using AutoMapper;
using domain.Entity;

namespace application.MappingProfiles
{
    public class ClienteProfile: Profile
    {
        public ClienteProfile() {
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<Cliente, ClienteDetailsDto>();
        }
    }
}

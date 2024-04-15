using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Features.Clientes.Commands.CreateCliente;
using application.Features.Clientes.Commands.DeleteCliente;
using application.Features.Clientes.Commands.UpdateCliente;
using application.Features.Clientes.Queries.GetAllCliente;
using application.Features.Clientes.Queries.GetClienteDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> Get()
        {
            try
            {
                List<ClienteDto> clienteDtos = await _mediator.Send(new GetClienteQuery());
                return  clienteDtos;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDetailsDto>> Get(Guid id)
        {
            try
            {
                ClienteDetailsDto clienteDetailsDto = await _mediator.Send(new GetClienteDetailsQuery(id));
                if (clienteDetailsDto == null)
                {
                    return NotFound();
                }
                return clienteDetailsDto;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateClienteCommand createCliente)
        {
            try { 
                var response = await _mediator.Send(createCliente);
                return CreatedAtAction(nameof(Get), new { id = response }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(Guid id, UpdateClienteCommand cliente)
        {
            try {
                cliente.Id = id;
                await _mediator.Send(cliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }

        }

        // DELETE api/values/5

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var command = new DeleteClienteCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
                    
        }
    }
}
;
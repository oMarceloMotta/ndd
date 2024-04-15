using System;
using MediatR;

namespace application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Observacao { get; set; } = string.Empty;
    }
}

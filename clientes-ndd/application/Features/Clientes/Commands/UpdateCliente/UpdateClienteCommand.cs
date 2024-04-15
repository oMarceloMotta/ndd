﻿using System;
using MediatR;

namespace application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Observacao { get; set; } = string.Empty;
    }
}
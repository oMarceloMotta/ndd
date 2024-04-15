using System;
using domain.Entity;
using domain.Repository;
using Moq;

namespace UnitTestes.Mocks
{
	public class MockClienteRepository
	{
        public static Mock<IClienteRepository> GetMockClienteRepository()
		{
            var clientes = new List<Cliente>
            {
                 new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Fulano de Tal",
                    CPF = "123.456.789-01",
                    Sexo = "Masculino",
                    Telefone = "(11) 98765-4321",
                    Email = "fulano@example.com",
                    DataNascimento = new DateTime(1985, 3, 12),
                    Observacao = "Cliente regular, sem observações especiais."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Ciclana Souza",
                    CPF = "987.654.321-02",
                    Sexo = "Feminino",
                    Telefone = "(21) 12345-6789",
                    Email = "ciclana@example.com",
                    DataNascimento = new DateTime(1990, 7, 25),
                    Observacao = "Cliente preferencial, solicita atendimento por telefone."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Beltrano Silva",
                    CPF = "456.789.012-03",
                    Sexo = "Masculino",
                    Telefone = "(31) 87654-3210",
                    Email = "beltrano@example.com",
                    DataNascimento = new DateTime(1978, 11, 5),
                    Observacao = "Cliente com histórico de compras em grande quantidade."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Sicrana Oliveira",
                    CPF = "321.654.987-04",
                    Sexo = "Feminino",
                    Telefone = "(41) 54321-0987",
                    Email = "sicrana@example.com",
                    DataNascimento = new DateTime(1982, 9, 18),
                    Observacao = "Cliente VIP, possui desconto especial."
                },
                
            };

            var mockRepo = new Mock<IClienteRepository>();
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(clientes);


            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Cliente>()))
                .Returns((Cliente cliente) => {
                    clientes.Add(cliente);
                    return Task.FromResult(cliente);
                });

            return mockRepo;
        }

	}
}


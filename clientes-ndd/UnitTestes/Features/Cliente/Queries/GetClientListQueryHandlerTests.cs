using System;
using application.Features.Clientes.Queries.GetAllCliente;
using application.MappingProfiles;
using AutoMapper;
using domain.Repository;
using Moq;
using Shouldly;
using UnitTestes.Mocks;

namespace UnitTestes.Features.Cliente.Queries
{
	public class GetClientListQueryHandlerTests
	{
		private readonly Mock<IClienteRepository> _mockRepo;
		private IMapper _mapper;
		public GetClientListQueryHandlerTests()
		{
			_mockRepo = MockClienteRepository.GetMockClienteRepository();

			var mapperConfiguration = new MapperConfiguration(c =>
			{
				c.AddProfile<ClienteProfile>();
			});

			_mapper = mapperConfiguration.CreateMapper();
		}

        [Fact]
        public async Task GetClienteListTest()
        {
			var handler = new GetClienteQueryHandler(_mapper, _mockRepo.Object);
			var result = await handler.Handle(new GetClienteQuery(), CancellationToken.None);
			result.Count.ShouldBe(4);
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.ShouldBeOfType<List<ClienteDto>>();

        }
    }
}



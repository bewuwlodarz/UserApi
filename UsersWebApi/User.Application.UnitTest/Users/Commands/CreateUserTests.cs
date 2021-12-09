using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Application.Contracts.Persistance;
using Users.Application.Functions.Users.Commands.CreateUser;
using Users.Application.Mapper;
using Users.Application.UnitTest.Mocks;
using Xunit;

namespace Users.Application.UnitTest.Users.Commands
{
    public class CreateUserTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public CreateUserTests()
        {
          
            _mockUserRepository =  RepositoryMocks.GetUserRepository();

            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfie>();
            });  
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidUser_AddedToUserRepo() 
        {
            var handler = new CreateUserCommandHandler(_mockUserRepository.Object, _mapper);
            var allUsersBeforeAddCount = (await _mockUserRepository.Object.GetAllAsync()).Count;

            var command = new CreateUserCommand()
            {
                Name = "Jason",
                Surname = "Taylor",
                EmailAddress = "cleanArchitecture@gmail.com"
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allUsersAfterAdd = (await _mockUserRepository.Object.GetAllAsync());

            response.Success.ShouldBe(true);
            response.ValidationErrors.Any().ShouldBeFalse();
            allUsersAfterAdd.Count.ShouldBe(allUsersBeforeAddCount + 1);
            response.UserId.ShouldNotBeNull();
        }
    }
}

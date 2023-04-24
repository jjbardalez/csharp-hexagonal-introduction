using Caba.Domain.Entities;
using Caba.Infraestructure.Repositories.User.CreateUser;
using MediatR;

namespace Caba.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, int>
    {
        private readonly ICreateUserRepository _createUserRepository;

        public CreateUserCommandHandler(ICreateUserRepository createUserRepository) 
        {
            _createUserRepository = createUserRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserModel user = new()
            {
                Name = request.Name,
                Email = request.Email
            };
            var result = await _createUserRepository.CreateUser(user);
            return result;
        }
    }
}

using MediatR;

namespace Caba.Application.Commands.User.CreateUser
{
    public class CreateUserCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

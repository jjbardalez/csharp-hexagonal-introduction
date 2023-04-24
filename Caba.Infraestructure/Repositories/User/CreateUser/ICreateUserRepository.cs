using Caba.Domain.Entities;

namespace Caba.Infraestructure.Repositories.User.CreateUser
{
    public interface ICreateUserRepository
    {
        public Task<int> CreateUser(UserModel user);
    }
}

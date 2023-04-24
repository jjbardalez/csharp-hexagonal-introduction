using Caba.Domain.Entities;
using Npgsql;
using Dapper;
using System.Data;
using System.Transactions;

namespace Caba.Infraestructure.Repositories.User.CreateUser
{
    public class CreateUserRepository: ICreateUserRepository
    {

        private readonly IDbConnection _connection;

        public CreateUserRepository(IDbConnection connection) {
        
            _connection = connection;
        }

        public  async Task<int> CreateUser(UserModel user) {

            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string insert = @"
                        insert into public.user (
                            name, email
                        )
                        values (
                            @name, @email
                        )";

                    int id = await connection.ExecuteAsync(insert, user);
                    trans.Complete();
                    return id;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}

using TaskBox.Domain.Interfaces.Repositories;
using TaskBox.Domain.Models;
using TaskBox.Infra.Data.Context;
using TaskBox.Infra.Data.Repositories.Base;

namespace TaskBox.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TaskBoxDbContext context) : base(context)
        {
        }
    }
}

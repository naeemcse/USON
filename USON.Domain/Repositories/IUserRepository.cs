using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USON.Domain.Entities;

namespace USON.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}

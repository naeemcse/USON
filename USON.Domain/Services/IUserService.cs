using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USON.Domain.Entities;

namespace USON.Domain.Services
{
    public interface IUserService
    {
        void AddUser (User user);
        void RemoveUser (User user);
        User GetUser (string username);
        void UpdateUser (User user);
    }
}

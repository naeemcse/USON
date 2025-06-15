using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USON.Application.DTOs;

namespace USON.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserDto> CreateAsync(RegisterUserDto userDto);
        Task<bool> UpdateAsync(Guid id, RegisterUserDto userDto);
        Task<bool> DeleteAsync(Guid id);
    }
}

using Microsoft.EntityFrameworkCore;
using USON.Application.DTOs;
using USON.Application.Interfaces;
using USON.Domain.Entities;
using USON.Infrastucture.Data;

namespace USON.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Mobile = u.Mobile,
                    UniversityName = u.UniversityName,
                    Email = u.Email,
                    Role = u.Role,
                    Sessition = u.Sessition,
                    DepartmentName = u.DepartmentName,
                    UnionName = u.UnionName,
                    WordNo = u.WordNo,
                    VillageName = u.VillageName,
                    SchoolName = u.SchoolName,
                    SSCPassingYear = u.SSCPassingYear,
                    CollegelName = u.CollegelName,
                    HSCPassingYear = u.HSCPassingYear,
                    Occupation = u.Occupation,
                    CurrentLocation = u.CurrentLocation,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Mobile = user.Mobile,
                UniversityName = user.UniversityName,
                Email = user.Email,
                Role = user.Role,
                Sessition = user.Sessition,
                DepartmentName = user.DepartmentName,
                UnionName = user.UnionName,
                WordNo = user.WordNo,
                VillageName = user.VillageName,
                SchoolName = user.SchoolName,
                SSCPassingYear = user.SSCPassingYear,
                CollegelName = user.CollegelName,
                HSCPassingYear = user.HSCPassingYear,
                Occupation = user.Occupation,
                CurrentLocation = user.CurrentLocation,
                CreatedAt = user.CreatedAt
            };
        }

        public async Task<UserDto> CreateAsync(RegisterUserDto registerDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password, // 🔒 Should be hashed in production
                Mobile = registerDto.Mobile,
                UniversityName = registerDto.UniversityName,
                Sessition = registerDto.Sessition,
                DepartmentName = registerDto.DepartmentName,
                UnionName = registerDto.UnionName,
                WordNo = registerDto.WordNo,
                VillageName = registerDto.VillageName,
                SchoolName = registerDto.SchoolName,
                SSCPassingYear = registerDto.SSCPassingYear,
                CollegelName = registerDto.CollegelName,
                HSCPassingYear = registerDto.HSCPassingYear,
                Occupation = registerDto.Occupation,
                CurrentLocation = registerDto.CurrentLocation,
                Role = registerDto.Role,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(user.Id); // reuses the GetByIdAsync mapping
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, RegisterUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password; // 🔒 Consider hashing
            user.Mobile = dto.Mobile;
            user.UniversityName = dto.UniversityName;
            user.Sessition = dto.Sessition;
            user.DepartmentName = dto.DepartmentName;
            user.UnionName = dto.UnionName;
            user.WordNo = dto.WordNo;
            user.VillageName = dto.VillageName;
            user.SchoolName = dto.SchoolName;
            user.SSCPassingYear = dto.SSCPassingYear;
            user.CollegelName = dto.CollegelName;
            user.HSCPassingYear = dto.HSCPassingYear;
            user.Occupation = dto.Occupation;
            user.CurrentLocation = dto.CurrentLocation;
            user.Role = dto.Role;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

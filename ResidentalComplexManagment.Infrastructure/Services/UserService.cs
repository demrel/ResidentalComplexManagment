using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Infrastructure.IdentityEntity;

namespace ResidentalComplexManagment.Infrastructure.Services
{
    public class UserService : IUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;


        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Add(UserDTO userDTO, string password)
        {
            var approle = await _roleManager.FindByNameAsync(userDTO.Role);
            if (approle == null) return;
            if (string.IsNullOrWhiteSpace(password)) return;
            var isUserExist = _userManager.Users.Any(c => c.UserName == userDTO.UserName);
            if (isUserExist) return;

            var user = new AppUser()
            {
                UserName = userDTO.UserName,
                Name = userDTO.Name,
                SurName = userDTO.SurName,
                MktId = userDTO.MktId
            };

            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, userDTO.Role);
        }
        public async Task SeedRoles()
        {
            foreach (var item in Enum.GetNames(typeof(UserRoles)))
            {
                await _roleManager.CreateAsync(new AppRole() { Name = item });
            }
        }

        public async Task<List<UserDTO>> GetList() =>
          await _userManager.Users.Select(c => new UserDTO()
          {
              Id = c.Id,
              Name = c.UserName,
              SurName = c.SurName,
              UserName = c.UserName,
              MktId = c.MktId,
              MtkName = c.Mkt.Name,
              Role = c.UserRoles.FirstOrDefault().Role.Name,
          }).ToListAsync();

        public async Task<UserDTO> GetById(string id) =>
            await _userManager.Users.Where(c => c.Id == id).Select(c => new UserDTO()
            {
                Name = c.UserName,
                SurName = c.SurName,
                UserName = c.UserName,
                MktId = c.MktId,
                Role = c.UserRoles.FirstOrDefault().Role.Name,
            }).FirstOrDefaultAsync();


        public async Task Update(UserDTO userDTO, string password)
        {

            var approle = await _roleManager.FindByNameAsync(userDTO.Role);
            if (approle == null) return;

            var user = await _userManager.Users.Include(c => c.UserRoles).ThenInclude(c => c.Role)
                                               .FirstOrDefaultAsync(c => c.UserName == userDTO.UserName);

            if (user == null) return;


            user.UserName = userDTO.UserName;
            user.Name = userDTO.Name;
            user.SurName = userDTO.SurName;
            user.MktId = userDTO.MktId;

            if (!string.IsNullOrEmpty(password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            }

            await _userManager.UpdateAsync(user);

            var userLastRole = user.UserRoles.FirstOrDefault().Role.Name;
            if (userDTO.Role != userLastRole)
            {
                await _userManager.RemoveFromRoleAsync(user, userLastRole);
                await _userManager.AddToRoleAsync(user, userDTO.Role);
            }
        }
    }


}

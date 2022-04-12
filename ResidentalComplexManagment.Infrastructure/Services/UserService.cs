using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResidentalComplexManagment.Infrastructure.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Infrastructure.Services
{
    public class UserService
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
            if (approle != null) return;

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


        public async Task<List<UserDTO>> GetList(string id) =>
          await _userManager.Users.Where(c => c.Id == id).Select(c => new UserDTO()
          {
              Name = c.UserName,
              SurName = c.SurName,
              UserName = c.UserName,
              MktId = c.MktId,
              Role = c.UserRoles.FirstOrDefault().Role.Name,
          }).ToListAsync();

        public async Task<UserDTO> GetById(string id) =>
            await _userManager.Users.Where(c => c.Id == id).Select(c => new UserDTO()
            {
               Name = c.UserName,
               SurName = c.SurName,
               UserName=c.UserName,
               MktId = c.MktId,
               Role=c.UserRoles.FirstOrDefault().Role.Name,
            }).FirstOrDefaultAsync();


        public async Task Update(UserDTO userDTO, string password)
        {

            var approle = await _roleManager.FindByNameAsync(userDTO.Role);
            if (approle == null) return;

            var user = await _userManager.FindByNameAsync(userDTO.UserName);

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


            await _userManager.AddToRoleAsync(user, userDTO.Role);
        }
    }

    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName => Name + " " + SurName;
        public string UserName { get; set; }
        public string MktId { get; set; }
        public string MtkName { get; set; }
        public string Role { get; set; }
    }
}

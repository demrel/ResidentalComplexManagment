using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    public interface IUser
    {
        Task Add(UserDTO userDTO, string password);
        Task<List<UserDTO>> GetList();
        Task<UserDTO> GetById(string id);
        Task Update(UserDTO userDTO, string password);
        Task SeedRoles();
    }
}

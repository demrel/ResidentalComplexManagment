using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
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

using Microsoft.AspNetCore.Identity;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Infrastructure.IdentityEntity;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string FullName => Name + " " + SurName;
    public string MktId { get; set; }
    public MKT Mkt { get; set; }
    public ICollection<AppUserRole> UserRoles { get; set; }

}


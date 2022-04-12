using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Infrastructure.IdentityEntity;

public class AppUserRole : IdentityUserRole<string>
{
    public int ID { get; set; }
    public virtual AppUser User { get; set; }
    public virtual AppRole Role { get; set; }
}

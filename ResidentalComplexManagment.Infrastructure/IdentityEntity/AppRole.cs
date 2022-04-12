﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Infrastructure.IdentityEntity;


public class AppRole : IdentityRole
{
    public ICollection<AppUserRole> UserRoles { get; set; }

}
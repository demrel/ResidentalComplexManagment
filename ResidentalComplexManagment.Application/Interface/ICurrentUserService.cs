using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string UserRole { get; }
        string GetNonAdminUserId { get; }
        bool IsAdminRole { get; }

    }
}

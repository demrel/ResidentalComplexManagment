using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Domain.GuardHelper
{
    internal static class ResidentGuardHelper
    {
        public static void IsNotCurrentResident(this IGuardClause guardClause, Resident input, string parameterName)
        {
            if (!input.IsCurrentResident)
                throw new ArgumentException("This resident is not current", parameterName);
        }
    }
}

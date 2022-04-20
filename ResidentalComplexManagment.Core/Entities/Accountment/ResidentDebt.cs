using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.Users;
using ResidentalComplexManagment.Core.Interface;
using ResidentalComplexManagment.Domain.Entities.Accountment;
using ResidentalComplexManagment.Domain.GuardHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.Accountment
{
    public class ResidentDebt : BaseEntity, IAggregateRoot
    {
        public decimal Value { get;private set; }
        public string  Description { get; private set; }
        public string ResidentId { get; private set; }
        public Resident Resident { get; private set; }

        public ResidentDebt() { }

        public ResidentDebt(Resident resident,decimal value)
        {
            Guard.Against.Null(resident, nameof(resident));
            Guard.Against.Negative(value, nameof(value));
            Guard.Against.IsNotCurrentResident(resident, nameof(resident));
            Resident = resident;
            Value = value;
        }

        




    }
}

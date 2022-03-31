using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class ResidentDTO : BaseDTO
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string FullName => Name + " " + Surname;
        public string FIN { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime? Birthday { get; private set; }
        public bool IsCurrentResident { get; private set; }
        public string AppartmentId { get; private set; }
    }
}

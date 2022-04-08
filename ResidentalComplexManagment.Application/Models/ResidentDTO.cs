using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class ResidentDTO : BaseDTO
    {
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public string FullName => Name + " " + Surname;
        public string FIN { get;  set; }
        public string PhoneNumber { get;  set; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { get;  set; }
        public bool IsCurrentResident { get;  set; }

        public string AppartmentId { get;  set; }
        public string BuildingId { get; set; }
        public string MKTID { get; set; }

        public string AppartmentName { get; set; }

        public string BuildingName { get; set; }
        public string MKTName { get; set; }

        public string ResidentState =>
            IsCurrentResident ? "bəli" : "xeyr";

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class AppartmentDTO :BaseDTO
    {
        public int DoorNumber { get;  set; }

        public string Name { get; set; }
        public decimal Area { get;  set; }
        public string MtkName { get; set; }
        public string BuildingName { get; set; }
        public string BuildingId { get;  set; }
        public string MtkId { get; set; }


    }
}

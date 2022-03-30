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
        public decimal Area { get;  set; }
        public string BuildingId { get;  set; }
       
    }
}

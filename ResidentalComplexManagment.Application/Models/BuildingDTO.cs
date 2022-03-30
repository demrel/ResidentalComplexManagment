using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class BuildingDTO : BaseDTO
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MKTId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class ResidentDebtItemDTO
    {
        public int Id { get; set; }
        public string ResidentId { get;  set; }
        public string PaymentItemId { get;  set; }
        public decimal DiscountPercent { get;  set; }
        
    }
}

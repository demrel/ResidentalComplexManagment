using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Models
{
    public class ResidentDebtItemDTOListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsCheckid { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string PaymentItemId { get;  set; }
    }
}

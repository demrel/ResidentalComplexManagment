using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Domain.Entities.Accountment
{
    public class ResidentDebtItemDiscount
    {
        public int Id { get; set; }
        public string ResidentId { get; private set; }
        //public Resident Resident { get; private set; }
        public string PaymentItemId { get; private set; }
        //public DebtItem PaymentItem { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public string  Description { get; private set; }

        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public bool IsActive { get; private set; }

        public ResidentDebtItemDiscount() { }

        public ResidentDebtItemDiscount(string paymentItemId, decimal discountPercent)
        {
            Guard.Against.NullOrWhiteSpace(paymentItemId, nameof(paymentItemId));
            Guard.Against.Negative(discountPercent, nameof(discountPercent));
            PaymentItemId = paymentItemId;
            DiscountPercent = discountPercent;
            IsActive = true;
            StartDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }

        public void MakeObsolote()
        {
            IsActive = false;
            EndDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }

        public void Change(string description)
        {
            Description = description;
        }
        

       
    }
}

using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Domain.Entities.Accountment
{
    public class ResidentDebtItem
    {
        [Key]
        public int Id { get; set; }
        public string ResidentId { get; private set; }
        //public Resident Resident { get; private set; }
        public string PaymentItemId { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public bool IsActive { get; private set; }

        public ResidentDebtItem() { }


        public ResidentDebtItem(string paymentItemId)
        {
            Guard.Against.NullOrWhiteSpace(paymentItemId, nameof(paymentItemId));
            PaymentItemId = paymentItemId;
            IsActive = true;
            StartDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }


        public void MakeObsolote()
        {
            IsActive = false;
            EndDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }




    }
}

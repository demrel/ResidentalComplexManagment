using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Domain.Entities.Accountment
{
    public class ResidentDebtItem
    {
        public int Id { get; set; }
        public string  ResidentId { get; private set; }
        public Resident Resident { get; private set; }
        public string PaymentItemId { get; private set; }
        public DebtItem PaymentItem { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public bool HasDisocunt => DiscountPercent > 0;

        public ResidentDebtItem()
        {

        }
        public ResidentDebtItem(string paymentItemId,decimal discountPercent)
        {
            Guard.Against.NullOrWhiteSpace(paymentItemId, nameof(paymentItemId));
            Guard.Against.NegativeOrZero(discountPercent, nameof(discountPercent));
            PaymentItemId = paymentItemId;
            DiscountPercent = discountPercent;

        }

        public ResidentDebtItem(string paymentItemId)
        {
            Guard.Against.NullOrWhiteSpace(paymentItemId, nameof(paymentItemId));
            PaymentItemId = paymentItemId;
        }

    }
}

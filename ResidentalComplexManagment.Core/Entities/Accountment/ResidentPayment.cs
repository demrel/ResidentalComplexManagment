using Ardalis.GuardClauses;
using ResidentalComplexManagment.Core.Entities.Users;
using ResidentalComplexManagment.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Core.Entities.Accountment;

public class ResidentPayment : BaseEntity, IAggregateRoot
{
    public decimal Value { get; set; }
    public string Detail { get; set; }
    public string TransactionId { get; set; }
    public string ResidentId { get; set; }
    public Resident Resident { get; set; }

    public ResidentPayment() { }
   
    public ResidentPayment(decimal value, string detail, string transactionId, string residentId)
    {
        Guard.Against.NegativeOrZero(value, nameof(value));
        Value = value;
        Detail = detail;
        TransactionId = transactionId;
        ResidentId = residentId;
    }
}


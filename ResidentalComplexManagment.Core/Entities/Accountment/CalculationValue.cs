using Ardalis.GuardClauses;
using ResidentalComplexManagment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Domain.Entities.Accountment;

public class CalculationValue
{
    public int Id { get;private set; }
    public decimal From { get; private set; }
    public decimal To { get; private set; }
    public decimal Value { get; private set; }
    public CalculationMethod Method { get; private set; }
    public string PaymentItemId { get; private set; }
    public DebtItem PaymentItem { get; private set; }
    public bool IsCurrent { get; private set; }
    public CalculationValue()
    {

    }

    public CalculationValue(decimal from,decimal to,decimal value, CalculationMethod method)
    {
        Guard.Against.NegativeOrZero(from, nameof(from));
        Guard.Against.NegativeOrZero(to, nameof(to));
        Guard.Against.NegativeOrZero(value, nameof(value));
        From = from;
        To = to;
        Value = value;
        Method = method;
        IsCurrent=true;
    }

    public CalculationValue(decimal value, CalculationMethod method)
    {
        Guard.Against.NegativeOrZero(value, nameof(value));
        Value = value;
        Method = method;
        IsCurrent = true;
    }

    public void MakeObsolote()
    {
        IsCurrent = false;
    }
}
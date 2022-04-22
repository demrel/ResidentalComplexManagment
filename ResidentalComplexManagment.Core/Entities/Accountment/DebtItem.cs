using ResidentalComplexManagment.Core.Entities;
using ResidentalComplexManagment.Core.Interface;
using ResidentalComplexManagment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Domain.Entities.Accountment
{
    public class DebtItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateOnly? From { get; private set; }
        public DateOnly? To { get; private set; }
        public bool IsComplusory { get; private set; }
        public PaymentItemType Type { get; private set; }

        private readonly List<CalculationValue> _calculationValues = new();

        public IReadOnlyCollection<CalculationValue> CalculationValues => _calculationValues.AsReadOnly();
      
        [NotMapped]
        public IReadOnlyCollection<CalculationValue> ActiveCalculationValues => _calculationValues.Where(c => c.IsCurrent).ToList().AsReadOnly();

        public DebtItem() { }

        public DebtItem(string name, DateOnly? from, DateOnly? to, bool isComplusory)
        {
            Name = name;
            From = from;
            To = to;
            Type = PaymentItemType.Seasonal;
            IsComplusory = isComplusory;
        }

        public DebtItem(string name, bool isComplusory)
        {
            Name = name;
            Type = PaymentItemType.Monthly;
            IsComplusory = isComplusory;
        }

        public decimal CalcualtePrice(decimal area)
        {
           return  ActiveCalculationValues.Where(c => c.From <= area && c.To >= area).FirstOrDefault().Value;
        }


        public void Update(string name, DateOnly? from, DateOnly? to, bool isComplusory)
        {
            Name = name;
            From = from;
            To = to;
            Type = PaymentItemType.Seasonal;
            IsComplusory = isComplusory;
        }



        public void AddCalculationValue(decimal from, decimal to, decimal value, CalculationMethod method)
        {
            _calculationValues.Add(new CalculationValue(from, to, value,method));
        }
        public void AddCalculationValue(decimal value, CalculationMethod method)
        {
            _calculationValues.Add(new CalculationValue(value,method));
        }
        public void ChangeCalculationValue(decimal value, int id, CalculationMethod method)
        {
            _calculationValues.FirstOrDefault(c => c.Id == id)?.MakeObsolote();
            AddCalculationValue(value, method);
        }
        public void ChangeCalculationValue(decimal from, decimal to, decimal value, int id, CalculationMethod method)
        {
            _calculationValues.FirstOrDefault(c => c.Id == id)?.MakeObsolote();
            AddCalculationValue(from, to, value, method);
        }
    }
}

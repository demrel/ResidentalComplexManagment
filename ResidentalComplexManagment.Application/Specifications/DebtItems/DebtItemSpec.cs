using Ardalis.Specification;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Domain.Entities.Accountment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Specifications.DebtItems
{
    internal class DebtItemSpec : Specification<DebtItem, DebtItemDTO>
    {
        public DebtItemSpec()
        {

            Query.Select(x => new DebtItemDTO
            {
                Id = x.Id,
                Name = x.Name,
                From = x.From,
                To = x.To,
                IsComplusory = x.IsComplusory,
                Type = x.Type.ToString(),

            });
        }

        public DebtItemSpec(string id)
        {
            Query.Select(x => new DebtItemDTO
            {
                Id = x.Id,
                Name = x.Name,
                From = x.From,
                To = x.To,
                IsComplusory = x.IsComplusory,
                Type = x.Type.ToString(),
                CalculationValueDTO= x.CalculationValues.Select(y=>new CalculationValueDTO()
                {
                    Id=y.Id,
                    From=y.From,
                    To=y.To,
                    Value=y.Value,
                    Method=y.Method,
                }).ToList()
            }).Where(c=>c.Id==id);
        }
    }
}

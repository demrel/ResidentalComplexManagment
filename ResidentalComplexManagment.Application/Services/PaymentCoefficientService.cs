using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Core.Entities.Accountment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Services
{
    public class PaymentCoefficientService : IPaymentCofficient
    {
        private readonly IRepository<PaymentCoefficient> _repository;

        public PaymentCoefficientService(IRepository<PaymentCoefficient> repository)
        {
            _repository = repository;
        }

        public async Task<List<PaymentCoefficientDTO>> GetAll() =>
           await _repository.ListAsync(new PaymentCoefficientSpec());

        public async Task<PaymentCoefficientDTO> GetBtyId(string id)
        {
          var data=await  _repository.GetByIdAsync(id);
            return new PaymentCoefficientDTO()
            {
                Id = data.Id,
                Time = data.Created,
                Note = data.Note,
                Value = data.Value,
            };
        }

        public async Task<decimal> GetCurrentCofficent()
        {
         return  await  _repository.GetBySpecAsync(new GetCurrentCofficentSpec());
         
        }

        public async Task Add(PaymentCoefficientDTO coefficientDTO)
        {
            var building = new PaymentCoefficient(coefficientDTO.Value, coefficientDTO.Note);
            await _repository.AddAsync(building);
        }
    }
}

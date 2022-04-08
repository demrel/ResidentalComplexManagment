using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    public interface IPaymentCofficient
    {
        Task<PaymentCoefficientDTO> GetBtyId(string id);
        Task<decimal> GetCurrentCofficent();
        Task Add(PaymentCoefficientDTO coefficientDTO);
        Task<List<PaymentCoefficientDTO>> GetAll();
    }
}

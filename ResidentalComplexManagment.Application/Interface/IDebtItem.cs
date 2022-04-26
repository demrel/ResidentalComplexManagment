using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    public interface IDebtItem
    {
        Task Add(DebtItemDTO dto);
        Task Update(DebtItemDTO dto);
        Task<List<DebtItemDTO>> GetList();
        Task<DebtItemDTO> GetById(string id);
        Task<List<SelectListItemDto>> GetSelectList();
        Task<bool> MakeObsoloteCalculation(string debtItemId, int calculationId);
    }
}

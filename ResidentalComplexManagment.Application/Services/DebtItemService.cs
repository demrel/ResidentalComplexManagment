using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications.DebtItems;
using ResidentalComplexManagment.Domain.Entities.Accountment;
using ResidentalComplexManagment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Services
{
    public class DebtItemService : IDebtItem
    {
        private readonly IRepository<DebtItem> _debtItemRep;

        public DebtItemService(IRepository<DebtItem> debtItemRep)
        {
            _debtItemRep = debtItemRep;
        }

        public async Task Add(DebtItemDTO dto)
        {
            DebtItem data = new (dto.Name, dto.From, dto.To, dto.IsComplusory);
            dto.CalculationValueDTO.ForEach(item => data.AddCalculationValue(item.From, item.To, item.Value, item.Method));
            await _debtItemRep.AddAsync(data);
        }

        public async Task Update(DebtItemDTO dto)
        {

            DebtItem data = await _debtItemRep.GetBySpecAsync(new DebtItemIncludeCalcSpec(dto.Id));
            data.Update(dto.Name, dto.From, dto.To, dto.IsComplusory);
            dto.CalculationValueDTO.ForEach(item => data.ChangeCalculationValue(item.From, item.To, item.Value, item.Id, item.Method));
            await _debtItemRep.SaveChangesAsync();
        }

        public async Task<bool> MakeObsoloteCalculation(string debtItemId, int calculationId)
        { 
            var data = await _debtItemRep.GetBySpecAsync(new DebtItemIncludeCalcSpec(debtItemId));
            if (data == null) return false;
            data.MakeObsoloteCalculationItem(calculationId);
            var changeCount= await _debtItemRep.SaveChangesAsync();
            return changeCount > 0;
        }

        public static List<string> GetCalculationValueSelectList() => Enum.GetNames(typeof(SelectListItemDto)).ToList();


        public async Task<List<DebtItemDTO>> GetList() => await _debtItemRep.ListAsync(new DebtItemSpec());

        public async Task<List<SelectListItemDto>> GetSelectList() => await _debtItemRep.ListAsync(new DebtItemSelectListSpec());

        public async Task<DebtItemDTO> GetById(string id) => await _debtItemRep.GetBySpecAsync(new DebtItemSpec(id));

    }
}

using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Application.Specifications.DebtItems;
using ResidentalComplexManagment.Application.Specifications.Residents;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.Users;
using ResidentalComplexManagment.Domain.Entities.Accountment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Services
{
    public class ResidentService : IResident
    {
        private readonly IRepository<Resident> _residentRepository;
        private readonly IRepository<Appartment> _appartmentRepository;
        private readonly IRepository<DebtItem> _debItemRepository;

        private readonly IUser _userService;

        public ResidentService(IRepository<Resident> residentRepository, IRepository<Appartment> appartmentRepository, IUser userService, IRepository<DebtItem> debItemRepository)
        {
            _residentRepository = residentRepository;
            _appartmentRepository = appartmentRepository;
            _userService = userService;
            _debItemRepository = debItemRepository;
        }

        public async Task Add(ResidentDTO residentDto)
        {
            var appartment = await _appartmentRepository.GetBySpecAsync(new IncludeAllResidentsInAppartmentSpec(residentDto.AppartmentId));
            if (appartment == null) return;

            var resident = new Resident(residentDto.Name, residentDto.Surname, residentDto.FIN, residentDto.PhoneNumber, residentDto.Birthday);
            appartment.AddNewResident(resident);
            await _residentRepository.AddAsync(resident);
        }

        public async Task Update(ResidentDTO residentDto)
        {
            var resident = await _residentRepository.GetByIdAsync(residentDto.Id);
            if (resident == null) return;
            resident.UpdateDetails(resident.Name, resident.Surname, resident.FIN, resident.PhoneNumber, resident.Birthday);
            await _residentRepository.SaveChangesAsync();
        }

        public async Task Delete(string residentId)
        {
            var resident = await _residentRepository.GetByIdAsync(residentId);
            if (resident == null) return;
            resident.ChangeRessidentStatus();
            await _residentRepository.SaveChangesAsync();
        }

        public async Task<List<ResidentDTO>> GetList() => await _residentRepository.ListAsync(new ResidentSpec());

        public async Task<List<ResidentDTO>> GetList(string userId)
        {
            var user = await _userService.GetById(userId);
            return await _residentRepository.ListAsync(new ResidentListByMtkSpec(user?.MktId));
        }
        public async Task<List<ResidentDTO>> GetResidentsByAppartment(string id) => await _residentRepository.ListAsync(new ResidentSpec(id));


        public async Task<ResidentDTO> GetById(string Id)
        {
            var resident = await _residentRepository.GetByIdAsync(Id);
            if (resident == null) return null;

            return new ResidentDTO()
            {
                Id = resident.Id,
                Name = resident.Name,
                Surname = resident.Surname,
                Birthday = resident.Birthday,
                FIN = resident.FIN,
                PhoneNumber = resident.PhoneNumber,
                IsCurrentResident = resident.IsCurrentResident,
                AppartmentId = resident.AppartmentId,
            };
        }

        public async Task AddDebtItems(List<ResidentDebtItemDTO> ids, string residentId)
        {

            var resident = await _residentRepository.GetByIdAsync(residentId);
            if (resident == null && !resident.IsCurrentResident) return;
            foreach (var item in ids)
            {
                resident.AddDebtItem(item.PaymentItemId, item.DiscountPercent);
            }
        }

        public async Task<List<ResidentDebtItemDTOListItem>> GetDebtItems(string residentId)
        {
            var resident = await _residentRepository.GetBySpecAsync(new ResidentIncludeDebItemAndAppartment(residentId));
            if (resident == null || !resident.IsCurrentResident) return null;

            var paymentItemIdList = resident.ResidentDebtItems.ToDictionary(b => b.PaymentItemId, b => b.DiscountPercent);

            var debtitems = await _debItemRepository.ListAsync(new DebtItemIncludeCalcSpec());
            return debtitems.Select(item => new ResidentDebtItemDTOListItem()
            {
                Name = item.Name,
                IsActive = item.IsComplusory,
                IsCheckid = item.IsComplusory || paymentItemIdList.ContainsKey(item.Id),
                Price = item.CalcualtePrice(resident.Appartment.Area),
                Discount = paymentItemIdList.GetValueOrDefault(item.Id),
                PaymentItemId = item.Id,
            }).ToList();

        }

        public async Task AddOrRemoveDebtItems(List<ResidentDebtItemDTOListItem> residentDebtItems, string residentId)
        {
            var resident = await _residentRepository.GetBySpecAsync(new ResidentIncludeDebItemAndAppartment(residentId));
            if (resident == null || !resident.IsCurrentResident) return;

            var data = residentDebtItems.Where(c => c.IsActive);
            foreach (var item in residentDebtItems)
            {
                if (item.IsCheckid) resident.AddDebtItem(item.PaymentItemId, item.Discount);
                else resident.RemoveDebtItem(item.PaymentItemId);
            }

        }



        //public async Task RemoveDebtItems(List<ResidentDebtItemDTO> ids, string residentId)
        //{

        //}

    }
}

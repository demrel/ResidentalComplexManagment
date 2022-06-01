using ResidentalComplexManagment.Application.Filters;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Application.Specifications.Appartments;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Services
{
    public class AppartmentService : IAppartment
    {
        private readonly IRepository<Appartment> _repository;
        private readonly IUser _userService;

        public AppartmentService(IRepository<Appartment> repository, IUser userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task Add(AppartmentDTO mtkDTo)
        {
            var apparment = new Appartment(mtkDTo.DoorNumber, mtkDTo.Area, mtkDTo.BuildingId);
            await _repository.AddAsync(apparment);
        }

        public async Task Update(AppartmentDTO mtkDTo)
        {
            var building = await _repository.GetByIdAsync(mtkDTo.Id);

            building.UpdateDetails(mtkDTo.DoorNumber, mtkDTo.Area);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            var mtk = await _repository.GetByIdAsync(Id);
            await _repository.DeleteAsync(mtk);
        }




        public async Task<PaginationList<AppartmentDTO>> GetAppartmentsByBuilding(string buildingId, string search, int currentPage, int pageItemSize)
        {
            var totalCount = await _repository.CountAsync(new AppartmenrtCountByBuildingFilterSpec(buildingId, search));
            var data = await _repository.ListAsync(new AppartmentSpecifiaction(buildingId, search, currentPage, pageItemSize));
            return new PaginationList<AppartmentDTO>(data, totalCount, currentPage, pageItemSize);

        }


        public async Task<List<AppartmentDTO>> GetList() =>
          await _repository.ListAsync(new AppartmentSpecifiaction());

        public async Task<PaginationList<AppartmentDTO>> GetList(string userId, string search, int currentPage, int pageItemSize)
        {
            var user = await _userService.GetById(userId);
            var totalCount = await _repository.CountAsync(new AppartmenrtCountByMtkFilterSpec(user?.MktId, search));
            var data = await _repository.ListAsync(new AppartmentListByMtkSpec(user?.MktId,  search,  currentPage,  pageItemSize));
            return new PaginationList<AppartmentDTO>(data, totalCount, currentPage, pageItemSize);
        }

        public async Task<AppartmentDTO> GetById(string Id) =>
             await _repository.GetBySpecAsync(new IncludeALlParamsToAppartment(Id));




        public async Task<List<SelectListItemDto>> GetSelectList(string mtkId) =>
             await _repository.ListAsync(new AppartmentSelectListSpec(mtkId));


    }
}

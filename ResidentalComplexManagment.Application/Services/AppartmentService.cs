using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
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

        public AppartmentService(IRepository<Appartment> repository)
        {
            _repository = repository;
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




        public async Task<List<AppartmentDTO>> GetAppartmentsByBuilding(string buildingId) =>
       await _repository.ListAsync(new AppartmentSpecifiaction(buildingId));

        public async Task<List<AppartmentDTO>> GetList() =>
          await _repository.ListAsync(new AppartmentSpecifiaction());

        public async Task<AppartmentDTO> GetById(string Id) =>
             await _repository.GetBySpecAsync(new IncludeALlParamsToAppartment(Id));




        public async Task<List<SelectListItemDto>> GetSelectList(string mtkId) =>
             await _repository.ListAsync(new AppartmentSelectListSpec(mtkId));


    }
}

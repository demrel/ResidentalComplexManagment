using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Services
{
    internal class BuildingService : IBuilding
    {
        private readonly IRepository<Building> _repository;

        public BuildingService(IRepository<Building> repository)
        {
            _repository = repository;
        }

        public async Task Add(BuildingDTO mtkDTo)
        {
            var building = new Building(mtkDTo.Number, mtkDTo.Name, mtkDTo.Address, mtkDTo.MKTId);
            await _repository.AddAsync(building);
        }

        public async Task Update(BuildingDTO mtkDTo)
        {
            var building = await _repository.GetByIdAsync(mtkDTo.Id);

            building.UpdateDetails(mtkDTo.Number, mtkDTo.Name, mtkDTo.Address);
            await _repository.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            var mtk = await _repository.GetByIdAsync(Id);
            await _repository.DeleteAsync(mtk);
        }

        public async Task GetList(string Id)
        {
            var mtk = await _repository.GetByIdAsync(Id);
            await _repository.DeleteAsync(mtk);
        }

        public async Task<List<BuildingDTO>> GetList() =>
          await _repository.ListAsync(new Buildingpecifiaction());

        public async Task<BuildingDTO> GetById(string id) =>
            await _repository.GetBySpecAsync(new IncludeALlParamsToBuilding(id));



        public async Task<List<SelectListItemDto>> GetSelectList(string mtkId) =>
              await _repository.ListAsync(new BuildingSelectListSpecifiaction(mtkId));

        public async Task<List<BuildingDTO>> GetBuildingsByMtk(string mtkId) =>
             await _repository.ListAsync(new Buildingpecifiaction(mtkId));

    }
}

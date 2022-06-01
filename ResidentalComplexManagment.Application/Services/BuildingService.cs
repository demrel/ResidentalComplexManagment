using ResidentalComplexManagment.Application.Filters;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Application.Specifications.Buildings;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;



namespace ResidentalComplexManagment.Application.Services
{
    internal class BuildingService : IBuilding
    {
        private readonly IRepository<Building> _repository;
        private readonly IUser _userService;

        public BuildingService(IRepository<Building> repository, IUser userService)
        {
            _repository = repository;
            _userService = userService;
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



        public async Task<List<BuildingDTO>> GetList() =>
          await _repository.ListAsync(new Buildingpecifiaction());

        public async Task<List<BuildingDTO>> GetList(string search) =>
         await _repository.ListAsync(new Buildingpecifiaction());


        public async Task<PaginationList<BuildingDTO>> GetList(string id, string search, int currentPage, int pageItemSize)
        {
            var user = await _userService.GetById(id);
            var totalCount = await _repository.CountAsync(new BuildingCountByFilterSpec(user?.MktId, search));
            var data = await _repository.ListAsync(new Buildingpecifiaction(user?.MktId, search, currentPage, pageItemSize));
            return new PaginationList<BuildingDTO>(data, totalCount, currentPage, pageItemSize);
        }

        public async Task<BuildingDTO> GetById(string id) =>
            await _repository.GetBySpecAsync(new IncludeALlParamsToBuilding(id));



        public async Task<List<SelectListItemDto>> GetSelectList(string mtkId) =>
              await _repository.ListAsync(new BuildingSelectListSpecifiaction(mtkId));

        public async Task<PaginationList<BuildingDTO>> GetBuildingsByMtk(string mtkId, string search, int currentPage, int pageItemSize)
        {
            var totalCount = await _repository.CountAsync(new BuildingCountByFilterSpec(mtkId, search));
            var data = await _repository.ListAsync(new Buildingpecifiaction(mtkId, search, currentPage, pageItemSize));
            return new PaginationList<BuildingDTO>(data, totalCount, currentPage, pageItemSize);
        }



    }
}

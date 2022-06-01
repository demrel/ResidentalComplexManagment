using ResidentalComplexManagment.Application.Filters;
using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    public interface IBuilding : IBase<BuildingDTO>
    {
        Task<List<SelectListItemDto>> GetSelectList(string mtkId);
        Task<PaginationList<BuildingDTO>> GetBuildingsByMtk(string mtkId, string search, int currentPage, int pageItemSize);
        Task<PaginationList<BuildingDTO>> GetList(string id, string search, int currentPage, int pageItemSize);
        Task<List<BuildingDTO>> GetList(string search);


    }
}

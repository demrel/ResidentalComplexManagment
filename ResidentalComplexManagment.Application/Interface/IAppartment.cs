using ResidentalComplexManagment.Application.Filters;
using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface;

public interface IAppartment : IBase<AppartmentDTO> 
{
    Task<List<SelectListItemDto>> GetSelectList(string buildingId);
    Task<PaginationList<AppartmentDTO>> GetAppartmentsByBuilding(string buildingId, string search, int currentPage, int pageItemSize);
    Task<PaginationList<AppartmentDTO>> GetList(string userId, string search, int currentPage, int pageItemSize);
}

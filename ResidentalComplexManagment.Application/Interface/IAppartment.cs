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
    Task<List<AppartmentDTO>> GetAppartmentsByBuilding(string buildingId);
}

using ResidentalComplexManagment.Application.Models;


namespace ResidentalComplexManagment.Application.Interface;

public interface IResident : IBase<ResidentDTO> {
    Task<List<ResidentDTO>> GetResidentsByAppartment(string id);
    Task<List<ResidentDTO>> GetList(string userId);
    Task<List<ResidentDebtItemDTOListItem>> GetDebtItems(string residentId);


}

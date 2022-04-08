using ResidentalComplexManagment.Application.Models;


namespace ResidentalComplexManagment.Application.Interface;

public interface IResident : IBase<ResidentDTO> {
    Task<List<ResidentDTO>> GetResidentsByAppartment(string id);
}

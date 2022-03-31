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
    public class ResidentService
    {
        private readonly IRepository<Resident> _residentRepository;
        private readonly IRepository<Appartment> _appartmentRepository;

        public ResidentService(IRepository<Resident> residentRepository, IRepository<Appartment> appartmentRepository)
        {
            _residentRepository = residentRepository;
            _appartmentRepository = appartmentRepository;
        }

        public async Task AddResident(string appartmentId,ResidentDTO residentDto)
        {
           var appartment = await _appartmentRepository.GetBySpecAsync(new IncludeAllResidentsInAppartmentSpec(appartmentId));
            if (appartment == null) return;

            var resident = new Resident(residentDto.Name, residentDto.Surname, residentDto.FIN, residentDto.PhoneNumber, residentDto.Birthday);
           appartment.AddNewResident(resident);
            await _appartmentRepository.UpdateAsync(appartment);
        }

        public async Task UpdateResident(ResidentDTO residentDto)
        {
            var resident =await _residentRepository.GetByIdAsync(residentDto.Id);
            if (resident == null) return;
            resident.UpdateDetails(resident.Name,resident.Surname,resident.FIN,resident.PhoneNumber,resident.Birthday);
            await _residentRepository.UpdateAsync(resident);
        }
        
        public async Task RemoveResident(string residentId)
        {
            var resident = await _residentRepository.GetByIdAsync(residentId);
            if (resident == null) return;
            await _residentRepository.DeleteAsync(resident);
        }

        public async Task<List<Resident>> GetAllResidents()=> await _residentRepository.ListAsync();


    }
}

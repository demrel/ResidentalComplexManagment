﻿using ResidentalComplexManagment.Application.Interface;
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
    public class ResidentService : IResident
    {
        private readonly IRepository<Resident> _residentRepository;
        private readonly IRepository<Appartment> _appartmentRepository;

        public ResidentService(IRepository<Resident> residentRepository, IRepository<Appartment> appartmentRepository)
        {
            _residentRepository = residentRepository;
            _appartmentRepository = appartmentRepository;
        }

        public async Task Add(ResidentDTO residentDto)
        {
           var appartment = await _appartmentRepository.GetBySpecAsync(new IncludeAllResidentsInAppartmentSpec(residentDto.AppartmentId));
            if (appartment == null) return;

            var resident = new Resident(residentDto.Name, residentDto.Surname, residentDto.FIN, residentDto.PhoneNumber, residentDto.Birthday);
           appartment.AddNewResident(resident);
            await _residentRepository.AddAsync(resident);
        }

        public async Task Update(ResidentDTO residentDto)
        {
            var resident =await _residentRepository.GetByIdAsync(residentDto.Id);
            if (resident == null) return;
            resident.UpdateDetails(resident.Name,resident.Surname,resident.FIN,resident.PhoneNumber,resident.Birthday);
            await _residentRepository.SaveChangesAsync();
        }
        
        public async Task Delete(string residentId)
        {
            var resident = await _residentRepository.GetByIdAsync(residentId);
            if (resident == null) return;
            resident.ChangeRessidentStatus();
            await _residentRepository.SaveChangesAsync();
        }

        public async Task<List<ResidentDTO>> GetList()=> await _residentRepository.ListAsync(new ResidentSpec());
        public async Task<List<ResidentDTO>> GetResidentsByAppartment(string id) => await _residentRepository.ListAsync(new ResidentSpec(id));


        public async Task<ResidentDTO> GetById(string Id) {
            var resident =await _residentRepository.GetByIdAsync(Id);
            if (resident == null) return null;

            return new ResidentDTO()
            {
                Id = resident.Id,
                Name = resident.Name,
                Surname = resident.Surname,
                Birthday = resident.Birthday,
                FIN = resident.FIN,
                PhoneNumber = resident.PhoneNumber,
                IsCurrentResident = resident.IsCurrentResident,
                AppartmentId = resident.AppartmentId,
            };
        }
       
    }
}

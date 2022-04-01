using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;

namespace ResidentalComplexManagment.Application.Services
{
    public class MTKService : IMTK
    {
        private readonly IRepository<MKT> _repository;

        public MTKService(IRepository<MKT> repository)
        {
            _repository = repository;
        }

        public async Task Add(MTKDTO mtkDTo)
        {
            var data = new MKT(mtkDTo.Name, mtkDTo.IBAN, mtkDTo.Address, mtkDTo.PhoneNumber);
            await  _repository.AddAsync(data);
        }

        public async Task Update(MTKDTO mtkDTo)
        {
            var mtk=await _repository.GetByIdAsync(mtkDTo.Id);
            mtk.UpdateDetails(mtkDTo.Name, mtkDTo.IBAN, mtkDTo.Address, mtkDTo.PhoneNumber);
            await _repository.UpdateAsync(mtk);
        }

        public async Task Delete(string Id)
        {
            var mtk = await _repository.GetByIdAsync(Id);
            await _repository.DeleteAsync(mtk);
        }

        public async Task<MTKDTO> GetById(string Id) 
        {
            var mtk=  await _repository.GetByIdAsync(Id);
            return new MTKDTO()
            {
                Id = mtk.Id,
                IBAN = mtk.IBAN,
                Address = mtk.Address,
                PhoneNumber = mtk.PhoneNumber,
                Name = mtk.Name,
                Created= mtk.Created,
            };

        }
        public async Task<List<MTKDTO>> GetList()=>
          await _repository.ListAsync(new MTKSpecifiaction());

        public async Task<List<SelectListItemDto>> GetMtkSelectList()=>
            await _repository.ListAsync(new MTKSelectListSpecifiaction());
        
    }
}

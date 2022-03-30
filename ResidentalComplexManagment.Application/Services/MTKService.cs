

using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Specifications;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;

namespace ResidentalComplexManagment.Application.Services
{
    public class MTKService
    {
        private readonly IRepository<MKT> _repository;

        public MTKService(IRepository<MKT> repository)
        {
            _repository = repository;
        }

        public async Task<MKT> Add(MTKDTo mtkDTo)
        {
           var data= new MKT(mtkDTo.Name, mtkDTo.IBAN, mtkDTo.Address, mtkDTo.PhoneNumber);
            return await  _repository.AddAsync(new MKT());
            //_repository.
        }

        public async Task Update(MTKDTo mtkDTo)
        {
            var mtk=await _repository.GetByIdAsync(mtkDTo.Id);

            mtk.UpdateDetails(mtkDTo.Name, mtkDTo.IBAN, mtkDTo.Address, mtkDTo.PhoneNumber);
            await _repository.UpdateAsync(new MKT());
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

        public async Task<List<MTKDTo>> GetList()=>
          await _repository.ListAsync(new MTKSpecifiaction());

      
    }
}

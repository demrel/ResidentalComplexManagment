using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    public interface IBase<T>
    {
        public Task Add(T entity);
        public Task Update(T entity);
        Task Delete(string Id);
        Task<List<T>> GetList();
        Task<T> GetById(string Id);
    }
}

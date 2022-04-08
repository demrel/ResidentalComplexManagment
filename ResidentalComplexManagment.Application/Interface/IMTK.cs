using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    public interface IMTK : IBase<MTKDTO>
    {
        Task<List<SelectListItemDto>> GetSelectList();
    }
}

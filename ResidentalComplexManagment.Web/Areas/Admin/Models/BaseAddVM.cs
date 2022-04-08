using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class BaseAddVM
    {
        private readonly List<SelectListItemDto> _mkts;
        public List<SelectListItemDto> Mkts { get => _mkts; set => _mkts.AddRange(value); }

        public BaseAddVM()
        {
            _mkts = new();
            _mkts.Add(new SelectListItemDto() { Id = "0", Name = "----------" });
        }
    }
}

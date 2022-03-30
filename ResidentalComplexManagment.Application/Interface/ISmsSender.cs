using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Application.Interface
{
    internal interface ISmsSender
    {
        Task SendAsync(List<SmsRecipeint> recipients);
    }
}

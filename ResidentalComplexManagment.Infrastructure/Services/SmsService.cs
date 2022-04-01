using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Infrastructure.Services;

public class SmsService : ISmsSender
{
    public Task SendAsync(List<SmsRecipeint> recipients)
    {
        throw new NotImplementedException();
    }
}


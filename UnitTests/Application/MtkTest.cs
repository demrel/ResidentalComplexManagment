using Microsoft.Extensions.DependencyInjection;
using Moq;
using ResidentalComplexManagment.Application.Interface;
using ResidentalComplexManagment.Application.Models;
using ResidentalComplexManagment.Application.Services;
using ResidentalComplexManagment.Core.Entities.ComplexInfrastructure;
using ResidentalComplexManagment.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Application
{
    public class MtkTest
    {
        private readonly string _buyerId = "Test buyerId";
        private readonly Mock<IMTK> _mockBasketRepo = new();

    
            

        [Fact]
        public void Add()
        {
          var dto=  new MTKDTO() { Address = "testaddress", Name = "TestName", IBAN = "testIban", PhoneNumber = "testPhoneNumber" };
            var basket = new MKT("TestName","testIban","testaddress","testPhoneNumber");

            _mockBasketRepo.Setup(x => x.Add(dto));

           
        }
    }
}

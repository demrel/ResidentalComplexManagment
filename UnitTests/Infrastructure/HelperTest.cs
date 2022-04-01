using ResidentalComplexManagment.Infrastructure.Helper;
using System;
using Xunit;

namespace UnitTests
{
    public class HelperTest
    {
        [Fact]
        public void GuidTOStringText()
        {
            string guidText = "21174896-c6a6-405a-82e7-8c11a159ba35";
            Guid guid = Guid.Parse(guidText);

             var result=  guid.GetAlphaNumeric();
            Assert.Equal("21174896c6a6405a82e78c11a159ba35", result);

        }
    }
}
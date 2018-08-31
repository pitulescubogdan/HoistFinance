using HoistFinance.Contract.Models;
using HoistFinance.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HoistFinance.Tests.UnitTests
{
    [TestClass]
    public class RequestControllerTests
    {
        [TestMethod]
        public void Test_Inserted_Requests_Returns_OK()
        {               
            //init
            var context = new FakeRequestContext();
            var controller = new RequestsController(context);

            var requests = new List<RequestModel>
            {
                
            };

            //act
            var result = controller.PostRequestModel(requests);

            //assert
            Assert.IsTrue("OK" == result.ReasonPhrase);
        }
    }
}

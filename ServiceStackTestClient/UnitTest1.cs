using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.Common;
using ServiceStack.ServiceClient.Web;
using ServiceStackLearning;

namespace ServiceStackTestClient
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            JsonServiceClient client = new JsonServiceClient("http://localhost:13399/");
            var response = client.Get(new Calculation() {Operand1 = 1, Operand2 = 5, Operator = "+"});
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result.Equals(6.0));
        }

        [TestMethod]
        public void TestModulus1()
        {
            JsonServiceClient client = new JsonServiceClient("http://localhost:13399/");
            CalculationResponse response;
            try
            {
                response = client.Get(new Calculation() { Operand1 = 1, Operand2 = 5, Operator = "%" });
            }
            catch (WebServiceException webEx)
            {
                Assert.IsNotNull(webEx);
            }
        }

    }
}

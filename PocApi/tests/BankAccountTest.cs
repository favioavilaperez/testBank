using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocApi.Utils;
using RestSharp;

namespace PocApi.tests
{
    [TestClass]
    public class BankAccountTest : RandomGeneratorCustomer
    {
        [TestMethod]
        public void VerifyCustomerCreation()
        {
            CustomerUtil.CreateCustomersAndGetStatusCode();
            var statusCode = CustomerUtil.CreateCustomersAndGetStatusCode();
            var statusCodeCustomer = Convert.ToInt32(statusCode);
            Assert.AreEqual(201, statusCodeCustomer, $"The customer was not created, verify the error");
        }

        [TestMethod]
        public void VerifyCustomerDeleted()
        {
            CustomerUtil.CreateCustomer();
            var getIdToken = CustomerUtil.GetCustomerId();
            string getId = getIdToken.ToString();
            var statusCodeDelete = CustomerUtil.DeleteCustomer(getId);
            var statusCode = Convert.ToInt32(statusCodeDelete);
            Assert.AreEqual(200, statusCode, $"Status code does not match expected");
        }

        [TestMethod]
        public void VerifyAcountCreation()
        {
            CustomerUtil.CreateCustomersAndGetStatusCode();
            var getIdToken = CustomerUtil.GetCustomerId();
            var getId = Convert.ToInt32(getIdToken);
            AccountUtil.CreateAccountAndGetStatusCode(getId);
            var statusCode = CustomerUtil.CreateCustomersAndGetStatusCode();
            var statusCodeCustomer = Convert.ToInt32(statusCode);
            Assert.AreEqual(201, statusCodeCustomer, $"The account was not created, verify the error");
        }

        [TestMethod]
        public void VerifyAcountDeleted()
        {
            var postCreateAccountResponse = CustomerUtil.CreateAccount("19", "951-678-4651");

            var hostName = new Uri("http://127.0.0.1:8000/");
            var restClient = new RestClient(hostName);

            var deleteeAccountRequest = new RestRequest("accounts/21/950-258-4435");
            var deleteeAccountResponse = restClient.Delete(deleteeAccountRequest);

            HttpStatusCode statusCode = deleteeAccountResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(200, numericStatusCode, $"The account was not deleted, please check the error");
        }
    }
}

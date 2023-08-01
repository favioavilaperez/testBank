using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PocApi.Utils;
using RestSharp;

namespace PocApi.tests
{
    [TestClass]
    public class BankAccountTest : RandomGenerator
    {
        [TestMethod]
        public void VerifyCustomerCreation()
        {
            var hostName = new Uri("http://127.0.0.1:8000/");
            var restClient = new RestClient(hostName);

            var createClientRequest = new RestRequest("customers/");
            createClientRequest.AddJsonBody(new
            {
                user = GenerateUserName(),
                email = GenerateEmail(),
                first_name = GenerateFirstName(),
                last_name = GenerateLastName(),
                password = "Control123$",
                address = GenerateAddress(),
                phone = GeneratePhone(),
            });

            var postCreateCustomerResponse = restClient.Post(createClientRequest);
            HttpStatusCode statusCode = postCreateCustomerResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(201, numericStatusCode, $"The customer was not created, verify the error");
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
            var hostName = new Uri("http://127.0.0.1:8000/");
            var restClient = new RestClient(hostName);

            var customerId = 41;

            var createAccountRequest = new RestRequest("accounts/");
            createAccountRequest.AddJsonBody(new
            {
                customer_id = customerId,
                account_number = "112121",
            });

            var postCreateAccountResponse = restClient.Post(createAccountRequest);
            HttpStatusCode statusCode = postCreateAccountResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(201, numericStatusCode, $"The account was not created, verify the error");
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

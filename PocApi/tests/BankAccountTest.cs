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
            getCustomerId.CreateCustomer("Amanda4", "Amanda4@gmail.com", "Amanda4", "Perez4", "Control123", "CBBA 235", "76508899");
            var customer = getCustomerId.GetCustomerId(getId);
            Console.WriteLine(customer);

            var hostName = new Uri("http://127.0.0.1:8000/");
            var restClient = new RestClient(hostName);
            

            var deleteCustomerRequest = new RestRequest("customer/");
            var deleteCustomerResponse = restClient.Delete(deleteCustomerRequest);

            HttpStatusCode statusCode = deleteCustomerResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(200, numericStatusCode, $"El código de estado no coincide con el esperado");
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
            Assert.AreEqual(201, numericStatusCode, $"Mensaje en caso de que falle");
        }

        [TestMethod]
        public void VerifyAcountDeleted()
        {
            var postCreateAccountResponse = CustomerUtil.CreateAccount("19", "951-678-4651", "100");

            var hostName = new Uri("http://127.0.0.1:8000/");
            var restClient = new RestClient(hostName);

            var deleteeAccountRequest = new RestRequest("accounts/21/950-258-4435");
            var deleteeAccountResponse = restClient.Delete(deleteeAccountRequest);

            HttpStatusCode statusCode = deleteeAccountResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(200, numericStatusCode, $"El código de estado no coincide con el esperado");
        }


    }
}

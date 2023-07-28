using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PocApi.Utils;
using RestSharp;

namespace PocApi.tests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void VerifyCustomerCreation()
        {
            var hostName = "http://127.0.0.1:8000/";

            var userName = "AutoUser-" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss");
            var options = new RestClientOptions(hostName);
            var client = new RestClient(options);

            var PostCreateClient = new RestRequest("customers/");
            PostCreateClient.AddBody(new
            {
                user = userName,
                email = userName + ".Perez.joo@gmail.com",
                first_name = "loco34",
                last_name = "Perez Sejas",
                password = "Control123",
                address = "Cala Cala 51225",
                phone = "75556789",
            });

            var postCreateCustomerResponse = client.Post(PostCreateClient);

            HttpStatusCode statusCode = postCreateCustomerResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(201, numericStatusCode, $"No se creao el usuario, verifique su error");
        }

        [TestMethod]
        public void VerifyCustomerDeleted()
        {
            var hostName = "http://127.0.0.1:8000/";

            var userName = "AutoUser-" + DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss");
            var options = new RestClientOptions(hostName);
            var client = new RestClient(options);

            var PostCreateClient = new RestRequest("customers/");
            PostCreateClient.AddBody(new
            {
                user = userName,
                email = userName + ".Perez.joo@gmail.com",
                first_name = "loco34",
                last_name = "Perez Sejas",
                password = "Control123",
                address = "Cala Cala 51225",
                phone = "75556789",
            });

            var postCreateCustomerResponse = client.Post(PostCreateClient);

            var hostNames = new Uri("http://127.0.0.1:8000/");
            var restClient = new RestClient(hostNames);

            var deleteCustomerRequest = new RestRequest("customer/31");
            var deleteCustomerResponse = restClient.Delete(deleteCustomerRequest);

            HttpStatusCode statusCode = deleteCustomerResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(200, numericStatusCode, $"El código de estado no coincide con el esperado");
        }

        [TestMethod]
        public void VerifyAcountCreation()
        {
            var hostName = "http://127.0.0.1:8000/";

            var options = new RestClientOptions(hostName);
            var client = new RestClient(options);

            var PostCreateAccount = new RestRequest("accounts/");
            PostCreateAccount.AddBody(new
            {
                customer_id = "19",
                account_number = "951-678-4651",
                balance = "100",
            });

            var postCreateAccountResponse = client.Post(PostCreateAccount);
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

        [TestMethod]
        public void VerifyCustomerGetList()
        {
            var hostName = "http://127.0.0.1:8000/";
            var restClient = new RestClient(hostName);

            var getRequest = new RestRequest("customers/");
            var getCustomerList = restClient.Get(getRequest);
            Console.WriteLine(getCustomerList);

            if (getCustomerList.IsSuccessful)
            {
                // Deserializar la respuesta JSON a una lista de objetos Customer
                var listaClientes = JsonConvert.DeserializeObject<List<Customer>>(getCustomerList.Content);

                // Obtener el último cliente creado
                var ultimoCliente = listaClientes.Count > 0 ? listaClientes[listaClientes.Count - 1] : null;

                if (ultimoCliente != null)
                {
                    var propiedad = ultimoCliente.customer_id;
                    Console.WriteLine("El customer_id del último cliente es: {0}", propiedad);
                }
                else
                {
                    Console.WriteLine("No hay clientes");
                }
            }
        }
    }
}

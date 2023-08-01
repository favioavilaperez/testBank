using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Utils
{
    public class CustomerUtil : RandomGenerator
    {
        public static string CreateCustomer()
        {
            var hostName = new Uri("http://127.0.0.1:8000/");
            var client = new RestClient(hostName);

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

            var postCreateCustomerResponse = client.Post(createClientRequest);

            if (postCreateCustomerResponse.StatusCode == HttpStatusCode.Created)
            {
                var createdCustomer = postCreateCustomerResponse.Content;
                return createdCustomer;
            }
            else
            {
                throw new Exception("Failed to create customer. Status code: " + (int)postCreateCustomerResponse.StatusCode);
            }
        }

        public static string CreateAccount(string costumerId, string accountNumber, string balance)
        {
            var hostName = new Uri("http://127.0.0.1:8000/");
            var client = new RestClient(hostName);

            var PostCreateAccount = new RestRequest("accounts/");
            PostCreateAccount.AddBody(new
            {
                customer_id = costumerId,
                account_number = accountNumber,
                balance = balance,
            });

            var postCreateAccountResponse = client.Post(PostCreateAccount);

            if (postCreateAccountResponse.StatusCode == HttpStatusCode.Created)
            {
                var createdAccount = postCreateAccountResponse.Content;
                return createdAccount;
            }
            else
            {
                throw new Exception("Failed to create customer. Status code: " + (int)postCreateAccountResponse.StatusCode);
            }
        }

        public static JToken GetCustomerId()
        {
            var hostName = new Uri("http://127.0.0.1:8000/");
            var client = new RestClient(hostName);

            var getListCustomers = new RestRequest("customers/");
            var getCustomerListResponse = client.Get(getListCustomers);
            var dataResponse = JToken.Parse(JsonConvert.SerializeObject(getCustomerListResponse));
            var customerId = dataResponse["customer_id"];
            return customerId;
        }

    }
}

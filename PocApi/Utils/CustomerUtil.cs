using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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
    public class CustomerUtil
    {
        public static string CreateCustomer(string username, string email, string firstName, string lastName, string password, string address, string phone)
        {
            var baseUrl = "http://127.0.0.1:8000/";
            var options = new RestClientOptions(baseUrl);
            var client = new RestClient(options);

            var createClientRequest = new RestRequest("customers/");
            createClientRequest.AddJsonBody(new
            {
                user = $"{username}{DateTime.Now:MM-dd-yyyy-hh-mm-ss}",
                email = $"{email}.joo@gmail.com",
                first_name = firstName,
                last_name = lastName,
                password = password,
                address = address,
                phone = phone,
            });

            var postCreateCustomerResponse = client.Post(createClientRequest);

            if (postCreateCustomerResponse.IsSuccessful)
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
    }
}

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
using System.Web.UI.WebControls;
using System.Web;
using System.IO;

namespace PocApi.Utils
{
    public class getCustomerId
    {
        public static string CreateCustomer(string username, string email, string firstName, string lastName, string password, string address, string phone)
        {
            var hostName = new Uri("http://127.0.0.1:8000/");
            var client = new RestClient(hostName);

            var createClientRequest = new RestRequest("customers/");
            createClientRequest.AddJsonBody(new
            {
                user = $"{username}AutoUser-{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}",
                email = email,
                first_name = firstName,
                last_name = lastName,
                password = password,
                address = address,
                phone = phone,
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

        public static string GetCustomerId(string getId)
        {
            var hostName = new Uri("http://127.0.0.1:8000/");
            var client = new RestClient(hostName);

            var getListCustomers = new RestRequest("customers/");
            var getCustomerListResponse = client.Get(getListCustomers);
            getId = getCustomerListResponse.GetType().GetProperty("customer_id");
            return getId;
            //obtener el costumer id de la lista


        }
    }

    public static string DeleteCustomerId(string customerId)
    {
        var hostName = new Uri("http://127.0.0.1:8000/");
        var client = new RestClient(hostName);

        var deleteCustomerIdResponse = new RestRequest("customers/" + customerId);

        var deleteCustomerResponse = client.Delete(deleteCustomerId);
        Console.WriteLine(deleteCustomerId);
        if (deleteCustomerId = HttpStatusCode.OK)
        {
            var customerDelete = deleteCustomerResponse.Content;
            return customerDelete;
        }
        else
        {
            throw new Exception("The customer can't be deleted" + (int)deleteCustomerResponse.StatusCode);
        }
    }
}

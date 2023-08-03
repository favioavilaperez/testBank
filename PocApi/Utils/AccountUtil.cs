using RestSharp;
using System;
using System.Net;

namespace PocApi.Utils
{
    public class AccountUtil: RandomGeneratorAccounts
    {
        public static string CreateAccountAndGetStatusCode(int customerId) 
        {
            var hostName = new Uri("http://127.0.0.1:8000/");
            var acccount = new RestClient(hostName);      
            var createAccountRequest = new RestRequest("account/create/");

            createAccountRequest.AddBody(new
            {
                customer_id = customerId,
                account_number = GenerateAccountNumber()
            });

            var postCreateAccountResponse =  acccount.Post(createAccountRequest);
          
            HttpStatusCode statusCode = postCreateAccountResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            return numericStatusCode.ToString();
        }
    }
}

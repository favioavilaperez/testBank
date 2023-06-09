using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace PocApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new RestClientOptions("http://127.0.0.1:8000/");
            var client = new RestClient(options);

            var getAccountForClient = new RestRequest("accounts/22");
            var getAccountResponse = client.Get(getAccountForClient);


            //Creacion Clientes
            var PostCreateClient = new RestRequest("customers/");

            PostCreateClient.AddBody(new
            {
                user = "Pepe",
                email = "Pepe.Perez.@gmail.com",
                first_name = "Pepe",
                last_name = "Perez Sejas",
                password = "Control123",
                address = "Cala Cala 5225",
                phone = "7889654",
            });

            //Delete Costumer

            var deleteCustomerForClient = new RestRequest("customer/21");

            var deleteCustomerResponse = client.Delete(deleteCustomerForClient);

            //Creacion Account
            var PostCreateAccount = new RestRequest("accounts/");

            PostCreateAccount.AddBody(new
            {
                customer_id = "26",
                account_number = "900-258-4420",
                balance = "100",
             });

            var postCreateAccountResponse = client.Post(PostCreateAccount);

            //Delete Account

            
            //Depostios
            var PostDepositAccount = new RestRequest("deposit/22");

            PostDepositAccount.AddBody(new
            {
                account_number = "951-258-4441",
                deposit = "100",
            });

            var postDepositResponse = client.Post(PostDepositAccount);

            //Retiros
            var PostWithdrawAccount = new RestRequest("withdraw/22");

            PostWithdrawAccount.AddBody(new
            {
                account_number = "951-258-4441",
                withdraw = "100",
            });

            var postWithdrawResponse = client.Post(PostWithdrawAccount);

        }
    }
}

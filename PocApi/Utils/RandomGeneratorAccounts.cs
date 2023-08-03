using System;

namespace PocApi.Utils
{
    public class RandomGeneratorAccounts
    {
        private static readonly string[] accountsNumbers = { "111-111-111", "222-222-222", "333-333-333" };

        public static string GenerateAccountNumber() 
        {
            var ramdom = new Random();
            string accountsNumber = accountsNumbers[ramdom.Next(0, accountsNumbers.Length)];
            return $"{accountsNumber}";
        }
    }
}

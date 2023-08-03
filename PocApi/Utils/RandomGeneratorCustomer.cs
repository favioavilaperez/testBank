using System;

namespace PocApi.Utils
{
    public class RandomGeneratorCustomer
    {
        private static readonly string[] userNames = { "Bartolome8", "Belen8", "Julian8", "Juliana8" };
        private static readonly string[] emails = { "Bartolome8@gmail.com", "Belen8@gmail.com", "Juliano8@gmail.com", "Juliana8@gmail.com" };
        private static readonly string[] firstNames = { "Bartolome8", "Belen8", "Julian8", "Juliana8" };
        private static readonly string[] lastNames = { "Burgos", "Perez", "Avila", "Ramirez" };
        private static readonly string[] addresses = { "Cala Cala 51225", "Casto Rojas 1235", "Beijing 264" };
        private static readonly string[] phones = { "79325478", "6926874", "7874513" };

        public static string GenerateUserName()
        {
            var random = new Random();
            string userName = userNames[random.Next(0, userNames.Length)];

            return $"{userName}";
        }

        public static string GenerateEmail()
        {
            var random = new Random();
            string email = emails[random.Next(0, emails.Length)];

            return $"{email}";
        }

        public static string GenerateFirstName()
        {
            var random = new Random();
            string firstName = firstNames[random.Next(0, firstNames.Length)];

            return $"{firstName}";
        }

        public static string GenerateLastName()
        {
            var random = new Random();
            string lastName = lastNames[random.Next(0, lastNames.Length)];

            return $"{lastName}";
        }

        public static string GenerateAddress()
        {
            var random = new Random();
            string address = addresses[random.Next(0, addresses.Length)];

            return $"{address}";
        }

        public static string GeneratePhone()
        {
            var random = new Random();
            string phone = phones[random.Next(0, phones.Length)];

            return $"{phone}";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Utils
{
    public class RandomGenerator
    {
        private static readonly string[] userNames = { "Juan01", "Carol27", "Sebas99", "Leonardo17" };
        private static readonly string[] emails = { "testemail01@gmail.com", "testemail02@gmail.com", "testemail03@gmail.com", "testemail04@gmail.com" };
        private static readonly string[] firstNames = { "John", "Paul", "Vanessa", "Jorge" };
        private static readonly string[] lastNames = { "Burgos", "Perez", "Rojas", "Ramirez" };
        private static readonly string[] addresses = { "Cala Cala 51225", "Casto Rojas 1235", "Beijing 264" };
        private static readonly string[] phones = { "793254788", "60926874", "78745123" };

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

        public static Random GetAccountNumber()
        {
            Random rnd = new Random();
            for (int j = 0; j < 1; j++)
            {
                Console.WriteLine(rnd.Next());
            }
            return rnd;
        }
    }


}
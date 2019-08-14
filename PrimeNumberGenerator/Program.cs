using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;

namespace PrimeNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Generating 100 Prime Numbers.");

           
            var primeNo = GetPrimes(100);

            WriteToTextFile(primeNo);

            primeNo.ForEach(x=> Console.WriteLine(x));

            Console.WriteLine("Enter the number first primes number display ?");

            var number = Console.ReadLine();
            int t;
            while (!int.TryParse(number, out t))
            {
                Console.WriteLine("Please enter a numeric value.");
                number = Console.ReadLine();
            }

            while ((int.Parse(number) <= 0))
            {
                Console.WriteLine("Please enter a value greater than 0.");
                number = Console.ReadLine();
            }

            Console.WriteLine($"Here are your {number} nth prime numbers.");

            primeNo.Take(int.Parse(number))
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }

        private static void WriteToTextFile(List<int> primeNo)
        {
            if(primeNo.Count == 0) return;

            var fileName = @"Prime_Numbers.txt";

            using (var str = new StreamWriter(fileName))
            {
                primeNo.ForEach(x=>str.WriteLine(x.ToString()));
            }
        }

        private  static List<int> GetPrimes(int range)
        {
            List<int> primeNo = new List<int> { 2,3};

            for (var x = 5; primeNo.Count < range; x += 2)
            {
                var isPrimeNo = true;
                foreach (var prime in primeNo)
                {
                    if (x % prime == 0)
                    {
                        isPrimeNo = false;
                        break;
                    }
                }
                if(isPrimeNo) 
                    primeNo.Add(x);
            }
            return primeNo;

        }
    }
}

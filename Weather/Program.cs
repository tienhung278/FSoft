using System;
using Weather.Contracts;
using Weather.Repositories;
using Weather.Services;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://api.weatherstack.com/current";
            var key = "access_key=610acf4c1d203448cd6f671955c5e8aa";
            RepositoryContext repoContext = new RepositoryContext(url, key);

            ILocationInfoRepository locationInfoRepo = new LocationInfoRepository(repoContext);

            LocationInfoServices locaionInfoServices = new LocationInfoServices(locationInfoRepo);

            Console.Write("Input your zipcode: ");
            string zipCode = Console.ReadLine();
            if (int.TryParse(zipCode, out int code))
            {
                locaionInfoServices.ZipCode = code;

                Console.WriteLine("How can I help you:");
                Console.WriteLine("\t 1. Should I go outside?");
                Console.WriteLine("\t 2. Should I wear sunscreen?");
                Console.WriteLine("\t 3. Can I fly my kite?");
                Console.Write("Which question do you want to ask (1 -> 3): ");

                string num = Console.ReadLine();
                if (int.TryParse(num, out int option))
                {
                    Console.WriteLine(locaionInfoServices.GetAnswer(option));
                }
                else
                {
                    Console.WriteLine("Your selecion is invalid");
                }
            }
            else
            {
                Console.WriteLine("Your zipcode must be in number");
            }            
        }
    }
}

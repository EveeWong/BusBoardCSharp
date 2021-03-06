using System;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoardCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a valid London postcode:");
            string postcode = Console.ReadLine();

            var client = new RestClient("https://api.postcodes.io/");
            var request = new RestRequest($"postcodes/{postcode}/validate", DataFormat.Json);
            var response = client.Get(request);

            Console.WriteLine(response.IsSuccessful);


        }

    }
}

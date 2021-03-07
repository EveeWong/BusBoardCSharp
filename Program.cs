using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BusBoardCSharp
{
    class Program
    {
   
        static void ValidatePostcode(string postcode)
        {

            var client = new RestClient("https://api.postcodes.io");
            var request = new RestRequest($"/postcodes/{postcode}", DataFormat.Json);
            var response = client.Get<PostcodeJsonModel>(request);
 


            if (response.IsSuccessful) {
                // Console.WriteLine(response.Content);
                // Console.WriteLine(response.Data.Result);
                // Console.WriteLine(response.Data.Result.Longitude);
                // Console.WriteLine(response.Data.Result.Latitude);

    
            } else {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);

            }
        }

        static void GetStopCode() {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest($"/Stoppoint?lat=51.508189&lon=-0.277934&stoptypes=NaptanPublicBusCoachTram");

            var response = client.Get<StopCodeJsonModel>(request);

            // Console.WriteLine(response.Content);
            Console.WriteLine(response.Data.NaptanId);

        }

        static void NextFiveBuses(string stopCode) {
            var client = new RestClient("https://api.postcodes.io/");
            var request = new RestRequest($"/StopPoint/${stopCode}/Arrivals", DataFormat.Json);
            var response = client.Get(request);

            Console.WriteLine(response.IsSuccessful);
            Console.WriteLine(response.Content);        

        }

        static void Main(string[] args)
        {
            // Console.WriteLine("Please enter a valid London postcode:");
            // string userPostcode = Console.ReadLine();

            // ValidatePostcode(userPostcode);

                GetStopCode();

    
        //     490003075QN

        }

    }
}

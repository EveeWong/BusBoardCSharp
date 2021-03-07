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
                string latitude = response.Data.Result.Latitude;
                string longitude = response.Data.Result.Longitude;

                GetStopCode(latitude, longitude);

    
            } else {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);

            }
        }

        static void GetStopCode(string latitude, string longitude) {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest($"/Stoppoint?lat={latitude}&lon={longitude}&stoptypes=NaptanPublicBusCoachTram");

            var response = client.Get<StopCodeJsonModel>(request);
            
            // Console.WriteLine(response.Content)
 
                Console.WriteLine(response.Data.stopPoints[0].NaptanId);
                Console.WriteLine(response.Data.stopPoints[1].NaptanId);

        
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
            Console.WriteLine("Please enter a valid London postcode:");
            string postcode = Console.ReadLine();

            ValidatePostcode(postcode);

        }

    }
}

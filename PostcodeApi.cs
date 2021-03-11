using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoardCSharp 
{
    public class PostcodeApi 
    {
            public static void ValidatePostcode(string postcode)
            {       
            var client = new RestClient("https://api.postcodes.io");
            var request = new RestRequest($"/postcodes/{postcode}", DataFormat.Json);
            var response = client.Get<PostcodeJsonModel>(request);
 

            if (response.IsSuccessful) {
         
                string latitude = response.Data.Result.Latitude;
                string longitude = response.Data.Result.Longitude;

                StopCodeApi.GetStopCode(latitude, longitude);

    
            } else {
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.ErrorException);

                    }

            }

    }   

}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoardCSharp 
{
    public class StopCodeApi 
    {
        public static void GetStopCode(string latitude, string longitude) 
        {
        var client = new RestClient("https://api.tfl.gov.uk");
        var request = new RestRequest($"/Stoppoint?lat={latitude}&lon={longitude}&stoptypes=NaptanPublicBusCoachTram");
        var response = client.Get<StopCodeJsonModel>(request);
            
            // Console.WriteLine(response.Content)

        string stopCode1 = response.Data.stopPoints[0].NaptanId;
        string stopCode2 = response.Data.stopPoints[1].NaptanId;

        GetBusesApi.NextFiveBuses(stopCode1);
        GetBusesApi.NextFiveBuses(stopCode2);
        
        }

    }   

}
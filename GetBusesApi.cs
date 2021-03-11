using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.Linq;

namespace BusBoardCSharp 
{
    public class GetBusesApi 
    {
        public static void NextFiveBuses(string stopCode) 
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest($"/StopPoint/{stopCode}/Arrivals", DataFormat.Json);
            var response = client.Get<List<BusesJsonModel>>(request);

            List<BusesJsonModel> busList = response.Data;

            List<BusesJsonModel> sortedBuses = busList.OrderBy(bus => bus.TimeToStation).ToList();

            Console.WriteLine("The nearest stop is " + response.Data[0].StationName + ".");
            for (int i = 0; i < 5; i++) {
                Console.WriteLine
                ("Bus number: " + sortedBuses[i].LineName + " heading towards " + sortedBuses[i].DestinationName 
                + " will arrive in approximately " + (sortedBuses[i].TimeToStation)/60 + " minute(s)."
                );
            }
            
        }

    }   

}
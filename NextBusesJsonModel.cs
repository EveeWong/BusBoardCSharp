using System;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoardCSharp
{
    //array of objects//
    public class NextBusesJsonModel
    {
      public string LineName { get; set; }

      public string DestinationName { get; set; }

      public int TimeToStation { get; set; }


    }
}

using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace BusBoardCSharp
{
    public class BusesJsonModel
    {
            public string StationName { get; set; }
            public string LineName { get; set; }
            public string DestinationName { get; set; }
            public int TimeToStation { get; set; }
    }
}
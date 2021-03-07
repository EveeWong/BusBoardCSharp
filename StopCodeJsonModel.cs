using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace BusBoardCSharp
{
    //array of objects//
    public class StopCodeJsonModel
    {
        public List<StopPointInfo> stopPoints { get; set; }
        public class StopPointInfo
        {
            public string NaptanId { get; set; }

        }


    }
}

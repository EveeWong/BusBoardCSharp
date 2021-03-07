using System;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoardCSharp
{
  //One big object holding two objects//
    public class PostcodeJsonModel
    {
      public int Status { get; set; }

      public ResultValues Result { get; set; } 

      public class ResultValues {
        public string Postcode { get; set; }
        public string Longitude { get; set; }

        public string Latitude { get; set; }
      }

    }
}

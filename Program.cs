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
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a valid London postcode:");
            string postcode = Console.ReadLine();

            PostcodeApi.ValidatePostcode(postcode);
        }

    }
}

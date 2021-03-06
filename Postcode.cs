// using System;
// using RestSharp;
// using RestSharp.Authenticators;

// namespace BusBoardCSharp
// {
//     public class Postcode
//     {
//         public void ValidatePostcode(string postcode)
//         {

//             var client = new RestClient("https://api.postcodes.io/");
//             var request = new RestRequest($"/postcodes/{postcode}/validate", DataFormat.Json);
//             var response = client.Get(request);

//             Console.WriteLine(response.IsSuccessful);
        

//         }

//     }
// }

using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeREST_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            var client = new HttpClient();

            do
            {

                var kanyeURL = "https://api.kanye.rest";

                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                Console.WriteLine($"{kanyeQuote}");

                //Ron section
                var ronURL = "http://ron-swanson-quotes.herokuapp.com/v2/quotes";

                var ronResponse = client.GetStringAsync(ronURL).Result;

                var ronQoute = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace('j', ' ').Trim();

                Console.WriteLine($"Ron says: {ronQoute}\n");

                Console.WriteLine("Continue? Y or N?");
                var response = Console.ReadLine().ToLower();
                cont = (response == "n") ? false : true;

            } while (cont);


        }
    }
}
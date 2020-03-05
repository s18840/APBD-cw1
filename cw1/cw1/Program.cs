using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //if (args.Length == 0) return;
            //nie zagniezdza nam sie kod
            var client = new HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl");
            //Task <T>
            // ThreadPool() daje nam to dostep do puli watkow
            //

            if (!result.IsSuccessStatusCode) return;

            string html = await result.Content.ReadAsStringAsync();

            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+",RegexOptions.IgnoreCase);
            //regex do czytania maili

            var matches = regex.Matches(html);
            foreach(var m in matches)
            {
                Console.WriteLine(m);
            }


            Console.WriteLine("Hello World!");

        }
    }
}

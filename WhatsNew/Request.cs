using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew
{
    public class Request
    {
        //Initialize associative collections using indexers
        private readonly Dictionary<int, string> webErrors = new Dictionary<int, string>
        {
            [404] = "Page not Found.",
            [302] = "Page moved, but left a forwarding address.",
            [500] = "The web server can't come out to play today."
        };

        private readonly Dictionary<int, string> webMessages = new Dictionary<int, string>
        {
            { 404, "Page not Found."},
            { 302, "Page moved, but left a forwarding address."},
            { 500, "The web server can't come out to play today."}
        };

        public Dictionary<int, string> WebErrors => webErrors;


        //Exception filters
        public static async Task<string> MakeRequest()
        {
            HttpClientHandler webRequestHandler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            using (HttpClient client = new HttpClient(webRequestHandler))
            {
                var stringTask = client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/about/");
                try
                {
                    var responseText = await stringTask;
                    return responseText;
                }
                catch (HttpRequestException e) when (e.Message.Contains("301"))
                {
                    return "Site Moved";
                }
                catch (Exception e) when (e.Message.Contains("Bad Request"))
                {
                    return "Bad Request";
                }
            }
        }

        //Await in Catch and Finally blocks
        public static async Task<string> MakeRequestAndLogFailures()
        {
            await LogMethodEntrance();
            var client = new HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (HttpRequestException e) when (e.Message.Contains("301"))
            {
                await LogError("Recovered from redirect", e);
                return "Site Moved";
            }
            catch (HttpRequestException e) when (e.Message.Contains("No connection"))
            {
                await LogError("No connection could be made because the target machine actively refused it", e);
                return "No connection could be made because the target machine actively refused it";
            }          
            finally
            {
                await LogMethodExit();
                client.Dispose();
            }
        }

        private static Task LogMethodExit()
        {
           return Task.Run(() => Console.WriteLine("Log"));
        }

        private static Task LogError(string v, HttpRequestException e)
        {
            return Task.Run(() => Console.WriteLine("Log"));
        }

        private static Task LogMethodEntrance()
        {
            return Task.Run(() => Console.WriteLine("Log"));
        }
    }
}

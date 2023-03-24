using RestSharp;
using System.Text.Json;

namespace Call_Elvis___IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("http://webservies.be/eurosong/Songs", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);

            List<Song> songs = JsonSerializer.Deserialize<List<Song>>(response.Content);
            foreach (var item in songs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
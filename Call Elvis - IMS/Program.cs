using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text.Json;

namespace Call_Elvis___IMS
{
    internal class Program
    {

        static async Task Do()
        {
            RestClient client = new RestClient();

            //songs eruit halen
            RestRequest request = new RestRequest("http://webservies.be/eurosong/Songs", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);
            //Console.WriteLine(response.StatusCode);
            List<Song> songs = JsonSerializer.Deserialize<List<Song>>(response.Content);

            //artists eruit halen
            request = new RestRequest("http://webservies.be/eurosong/Artists", Method.Get);
            response = await client.ExecuteAsync(request);
            List<Artist> artists = JsonSerializer.Deserialize<List<Artist>>(response.Content);

            string artist = "";

            foreach (Song item in songs)
            {
                artist = artists.Find(x => x.id == item.artist).name;
                Console.WriteLine($"{item.title} wordt gezongen door {artist}");
            }

            Song song = songs.Find(x => x.title == "Hello");
            artist = artists.Find(x => x.id == song.artist).name;

            string url = $"https://spotify-scraper.p.rapidapi.com/v1/track/download/soundcloud?track={song.title}%20{artist}";
            request = new RestRequest(url, Method.Get);
            request.AddHeader("X-RapidAPI-Key", "key");
            request.AddHeader("X-RapidAPI-Host", "spotify-scraper.p.rapidapi.com");
            response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            //gebruik https://codebeautify.org/jsonviewer om json code leesbaarder te maken

            dynamic data = JObject.Parse(response.Content);
            Console.WriteLine(data.spotifyTrack.shareUrl);

        }

        static void Main(string[] args)
        {
            var task = Do();
            task.Wait();

        }
    }
}
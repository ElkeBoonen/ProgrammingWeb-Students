using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FRONTEND___IMS
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new RestClient();
            var request = new RestRequest(@"https://localhost:5001/Songs", Method.Get);

            var response = await client.ExecuteAsync(request);

            Console.WriteLine(response.Content);

            List<Song> songs = JsonSerializer.Deserialize<List<Song>>(response.Content);
            Console.WriteLine(String.Join("\n",songs));

            /*foreach (var item in songs)
            {
                Console.WriteLine(item);
            }*/

            Console.WriteLine("Kies een nummer: ");
            int songId = Convert.ToInt32(Console.ReadLine());

            Song song = songs.Find(s => s.id == songId);


            request = new RestRequest(@"https://localhost:5001/Artists/" + song.artist, Method.Get);
            response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Artist artist = JsonSerializer.Deserialize<Artist>(response.Content);

                string url = "https://spotify-scraper.p.rapidapi.com/v1/track/download/soundcloud?track=";
                string track = Uri.EscapeUriString(song.title + " " + artist.name);

                request = new RestRequest(url+track, Method.Get);
                request.AddHeader("X-RapidAPI-Key", "API-KEY");
                request.AddHeader("X-RapidAPI-Host", "spotify-scraper.p.rapidapi.com");
                response = await client.ExecuteAsync(request);

                dynamic data = JObject.Parse(response.Content);
                Console.WriteLine(data.spotifyTrack.shareUrl);

                song.spotify = data.spotifyTrack.shareUrl;
                request = new RestRequest(@"https://localhost:5001/Songs?id=" + song.id, Method.Put);
                request.AddStringBody(JsonConvert.SerializeObject(song), "application/json");
                response = await client.ExecuteAsync(request);
                Console.WriteLine(response.StatusCode + " " + response.Content);

            }
            else Console.WriteLine(response.Content.ToString());


        }
    }
}

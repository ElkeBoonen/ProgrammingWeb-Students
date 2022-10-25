using System;
using System.Collections.Generic;
using System.Text.Json;
using RestSharp;


namespace FRONTEND___IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient();
            var request = new RestRequest(@"https://localhost:5001/Songs", Method.Get);
            var response = client.Execute(request);

            Console.WriteLine(response.Content);

            List<Song> songs = JsonSerializer.Deserialize<List<Song>>(response.Content);
            Console.WriteLine(String.Join("\n",songs));

            Console.WriteLine("Kies een nummer: ");
            int songId = Convert.ToInt32(Console.ReadLine());

            Song song = songs.Find(s => s.id == songId);


            request = new RestRequest(@"https://localhost:5001/Artists/" + song.artist, Method.Get);
            response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Artist artist = JsonSerializer.Deserialize<Artist>(response.Content);

                string url = "https://spotify-scraper.p.rapidapi.com/v1/track/download/soundcloud?track=";
                string track = Uri.EscapeUriString(song.title + " " + artist.name);

                request = new RestRequest(url+track, Method.Get);
                request.AddHeader("X-RapidAPI-Key", "");
                request.AddHeader("X-RapidAPI-Host", "spotify-scraper.p.rapidapi.com");
                response = client.Execute(request);

                Console.WriteLine(response.Content);


            }
            else Console.WriteLine(response.Content.ToString());


         

            /*foreach (var item in songs)
            {
                Console.WriteLine(item);
            }*/
        }
    }
}

using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text.Json;

namespace Call_Elvis___DSPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient();
            
            //GETTING AL SONGS
            RestRequest request = new RestRequest("http://webservies.be/eurosong/Songs", Method.Get);
            RestResponse response = client.Execute(request);

            //content as a string
            Console.WriteLine(response.Content);
            //deserialize the content into a list of Song-object
            List<Song> songs = JsonSerializer.Deserialize<List<Song>>(response.Content);

            //GETTING AL ARTISTS
            request = new RestRequest("http://webservies.be/eurosong/Artists", Method.Get);
            response = client.Execute(request);
            List<Artist> artists = JsonSerializer.Deserialize<List<Artist>>(response.Content);

            string artistname = "";
            foreach (Song song in songs)
            {
                artistname = artists.Find(a => a.id == song.artist).name;
                Console.WriteLine(song.title + " from artist " + artistname);
            }

            Song hello = songs[songs.Count - 1];

            request = new RestRequest("https://spotify-scraper.p.rapidapi.com/v1/track/download/soundcloud?track="
                + Uri.EscapeUriString(hello.title + " " + artistname), Method.Get);
            request.AddHeader("X-RapidAPI-Key", "KEY");
            request.AddHeader("X-RapidAPI-Host", "spotify-scraper.p.rapidapi.com");
            response = client.Execute(request);
            Console.WriteLine(response.Content);

            dynamic data = JObject.Parse(response.Content);

            //https://codebeautify.org/jsonviewer

            Console.WriteLine(data.spotifyTrack.shareUrl);


        }
    }
}
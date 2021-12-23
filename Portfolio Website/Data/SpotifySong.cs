using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Portfolio_Website.Data
{

    [JsonObject]
    public class SpotifyJsonWrapper
    {
        [JsonProperty("track")]
        public Track Song { get; set; }

        [JsonProperty("played_at")]
        public DateTime PlayedAt { get; set; }

    };

    [JsonObject]
    public class Track
    {

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("duration_ms")]
        public int Duration { get; set; }

        [JsonProperty("explicit")]
        public bool IsExpicit { get; set; }

        [JsonProperty("href")]
        public string APICall { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrl { get; set; }

        public Artist Artist => this.Artists.Count == 1 ? this.Artists[0] : null;
    }

    [JsonObject]
    public class Album
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrl { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }

    [JsonObject]
    public class Image
    {
        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }



    [JsonObject]
    public class Artist
    {
        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    [JsonObject]
    public class ExternalUrl
    {
        [JsonProperty("spotify")]
        public string SpotifyUrl { get; set; }
    }

}

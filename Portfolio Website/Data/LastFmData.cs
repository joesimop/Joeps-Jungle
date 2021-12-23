using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Portfolio_Website.Data
{
    [JsonObject]
    public class LstFmApiCallAttributes
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("perPage")]
        public int ResultsPerPage { get; set; }

        [JsonProperty("total")]
        public int TotalResults { get; set; }
    }

    [JsonObject]
    public class LastFmAttributesWrapper
    {
        [JsonProperty("recenttracks")]
        public SingleRecentTrackWrapper Wrapper { get; set; }

        [JsonProperty("@attr")]
        public SingleRecentTrackWrapper Attributes { get; set; }

    }

    [JsonObject]
    public class SingleRecentTrackWrapper
    {
        [JsonProperty("@attr")]
        public LstFmApiCallAttributes Attributes { get; set; }
    }

    [JsonObject]
    public class RecentTracksWrapper
    {
        [JsonProperty("recenttracks")]
        public LastFmTrackList TrackList { get; set; } = new();

    }

    [JsonObject]
    public class LastFmTrackList
    {
        [JsonProperty("track")]
        public List<LastFmTrack> Tracks { get; set; } = new();

    }


    [JsonObject]
    public class LastFmTrack
    {
        [JsonProperty("artist")]
        public LastFmArtist Artist { get; set; } = new();

        [JsonProperty("album")]
        public LastFmAlbum Album { get; set; } = new();

        [JsonProperty("image")]
        public List<LastFmImage> Images { get; set; } = new();

        [JsonProperty("mbid")]
        public string Mbid { get; set; } = string.Empty!;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty!;

        [JsonProperty("date")]
        public LastFmTimeData TimeData { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty!;


    }

    [JsonObject]
    public class LastFmArtist
    {
        [JsonProperty("#text")]
        public string Name { get; set; } = string.Empty!;

        [JsonProperty("mbid")]
        public string Mbid { get; set; } = string.Empty!;

    }

    [JsonObject]
    public class LastFmAlbum
    {
        [JsonProperty("#text")]
        public string Name { get; set; } = string.Empty!;

        [JsonProperty("mbid")]
        public string Mbid { get; set; } = string.Empty!;

    }

    [JsonObject]
    public class LastFmImage
    {
        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("#text")]
        public string Url { get; set; }

    }

    [JsonObject]
    public class LastFmTimeData
    {
        [JsonProperty("uts")]
        public double UnixTimeStamp { get; set; }
            
        [JsonProperty("#text")]
        public string Written { get; set; }

    }
}

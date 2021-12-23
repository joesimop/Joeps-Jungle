using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Data
{
    [JsonObject]
    public class DetailedStravaActivity
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty!;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty!;

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("moving_time")]
        public double MovingTime { get; set; }

        [JsonProperty("elapsed_time")]
        public double ElapsedTime { get; set; }

        public double TimeDiffernce => ElapsedTime - MovingTime;

        [JsonProperty("total_elevation_gain")]
        public double ElevatoinGain { get; set; }

        [JsonProperty("elev_high")]
        public double ElevationHigh { get; set; }

        [JsonProperty("elev_low")]
        public double ElevationLow { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty!;

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty!;

        [JsonProperty("start_date_local")]
        public DateTime StartDate { get; set; }

        [JsonProperty("calories")]
        public double Calories { get; set; }

        [JsonProperty("kudos_count")]
        public int KudosCount { get; set; }

        [JsonProperty("total_photo_count")]
        public int PhotoCount { get; set; }

        [JsonProperty("achievement_count")]
        public int AchievementCount { get; set; }

        [JsonProperty("average_speed")]
        public double AverageSpeed { get; set; }

        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty("splits_standard")]
        public List<StandardSplit> Splits { get; set; } = new();

        [JsonProperty("map")]
        public StravaMap Map { get; set; } = new();

        [JsonProperty("photos")]
        public PhotoContainer photo { get; set; }

        public RecentTracksWrapper PlayedSongs { get; set; } = new();

        public int PolyLineLength { get; set; } = 0;

    }

    [JsonObject]
    public class StandardSplit
    {

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("moving_time")]
        public double MovingTime { get; set; }

        [JsonProperty("elapsed_time")]
        public double ElapsedTime { get; set; }

        [JsonProperty("elevation_difference")]
        public double ElevatoinDifference { get; set; }

        [JsonProperty("average_speed")]
        public double AverageSpeed { get; set; }

        [JsonProperty("average_grade_adjusted_speed")]
        public double GradeAdjustedAverageSpeed { get; set; }
    }


    [JsonObject]
    public class StravaMap
    {

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty!;

        [JsonProperty("polyline")]
        public string Polyline { get; set; } = string.Empty!;

        [JsonProperty("summary_polyline")]
        public string SummaryPolyline { get; set; } = string.Empty!;

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }

    [JsonObject]
    public class PhotoContainer
    {

        [JsonProperty("primary")]
        public StravaPhoto Container { get; set; }

    }

    [JsonObject]
    public class StravaPhoto
    {

        [JsonProperty("unique_id")]
        public string Id { get; set; }

        [JsonProperty("urls")]
        public PhotoLinks PhotoLinks { get; set; }


    }

    [JsonObject]
    public class PhotoLinks
    {

        [JsonProperty("100")]
        public string LowRes { get; set; }

        [JsonProperty("600")]
        public string HighRes { get; set; }
    }
}

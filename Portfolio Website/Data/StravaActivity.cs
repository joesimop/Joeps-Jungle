using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Data
{

    [JsonObject]
    public class StravaActivity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("moving_time")]
        public double MovingTime { get; set; }

        [JsonProperty("elapsed_time")]
        public double ElapsedTime { get; set; }

        [JsonProperty("total_elevation_gain")]
        public double ElevatoinGain { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("start_date_local")]
        public DateTime StartDate { get; set; }

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

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

    }
}

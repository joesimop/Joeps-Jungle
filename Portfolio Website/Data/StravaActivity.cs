using Newtonsoft.Json;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio_Website.Data
{

    [JsonObject]
    public class StravaActivity
    {
        [JsonProperty("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [JsonProperty("distance")]
        [BsonRepresentation(BsonType.Double)]
        public double Distance { get; set; }

        [JsonProperty("moving_time")]
        [BsonRepresentation(BsonType.Double)]
        public double MovingTime { get; set; }

        [JsonProperty("elapsed_time")]
        [BsonRepresentation(BsonType.Double)]
        public double ElapsedTime { get; set; }

        [JsonProperty("total_elevation_gain")]
        [BsonRepresentation(BsonType.Double)]
        public double ElevatoinGain { get; set; }

        [JsonProperty("type")]
        [BsonRepresentation(BsonType.String)]
        public string Type { get; set; }

        [BsonRepresentation(BsonType.String)]
        [JsonProperty("id")]    
        public string Id { get; set; }
        

        [JsonProperty("start_date_local")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime StartDate { get; set; }

        [JsonProperty("kudos_count")]
        [BsonRepresentation(BsonType.Int32)]
        public int KudosCount { get; set; }

        [JsonProperty("total_photo_count")]
        [BsonRepresentation(BsonType.Int32)]
        public int PhotoCount { get; set; }

        [JsonProperty("achievement_count")]
        [BsonRepresentation(BsonType.Int32)]
        public int AchievementCount { get; set; }

        [JsonProperty("average_speed")]
        [BsonRepresentation(BsonType.Double)]
        public double AverageSpeed { get; set; }

        [JsonProperty("comment_count")]
        [BsonRepresentation(BsonType.Int32)]
        public int CommentCount { get; set; }

        [JsonProperty("private")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool IsPrivate { get; set; }

    }
}

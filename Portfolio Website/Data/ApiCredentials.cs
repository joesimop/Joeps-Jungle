namespace Portfolio_Website.Data
{
    public class SpotifyCredentials
    {
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
        public string Authorization { get; set; } = null!;
    }

    public class StravaCredentials
    {
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }

    public class MapBoxCredentials
    {
        public string AccessToken { get; set; } = null!;

    }

    public class LastFMCredentials
    {
        public string APIKey { get; set; } = null!;
        public string SharedSecret { get; set; } = null!;
    }
}

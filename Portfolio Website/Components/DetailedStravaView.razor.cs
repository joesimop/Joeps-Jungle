using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Portfolio_Website.Data;
using Portfolio_Website.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Components
{
    public partial class DetailedStravaView : ComponentBase
    {
        [Inject] IJSRuntime js { get; set; } = default!;

        [Inject] IOptions<LastFMCredentials> LastFMCredentials { get; init; } = default!;

        [Inject] IOptions<MapBoxCredentials> MapBoxCredentials { get; init; } = default!;

        [Parameter] public DetailedStravaActivity Activity { get; set; } = new();

        public LoadState DataState { get; set; } = LoadState.Loading;

        private ElementReference SliderInput;

        private string PreviousActivityId { get; set; } = string.Empty!;

        private double BaseTime { get; set; }

        private double DistanceTraveled { get; set; }

        private double SliderValue { get; set; }

        private LastFmTrack CurrentTrack { get; set; } = new();

        private double ratio { get; set; }

        private bool HasSongs => this.Activity.PlayedSongs.TrackList.Tracks.Any();

        protected override async Task OnAfterRenderAsync(bool FirstRender)
        {
            if (FirstRender)
            {
                await js.InvokeVoidAsync("SetLastFMCredentials",
                        this.LastFMCredentials.Value.APIKey,
                        this.LastFMCredentials.Value.SharedSecret);

                await js.InvokeVoidAsync("SetMapBoxCredentials",
                        this.MapBoxCredentials.Value.AccessToken);
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            //Keep from reinitialization
            if (this.Activity.Id != string.Empty && this.Activity.Id != PreviousActivityId)
            {
                this.PreviousActivityId = this.Activity.Id;
                this.DataState = LoadState.Loading;
                await NewActivityInitialization();
                this.DataState = LoadState.ValidResults;
                this.StateHasChanged();
                    
                await this.js.InvokeVoidAsync("mapInit");

            }
        }

        private async Task NewActivityInitialization()
        {
            await GetPolyline();
            await GetSongs();
        }

        private async Task GetPolyline()
        {
            this.Activity.PolyLineLength = await this.js.InvokeAsync<int>("decode", this.Activity.Map.Polyline);
        }

        private async Task GetSongs()
        {
            this.Activity.PlayedSongs = new();
            double from = this.Activity.StartDate.ToUnixTimeStamp();
            double to = from + this.Activity.ElapsedTime;

            string jsonString = await js.InvokeAsync<string>("GetPlayedTracksDuringActivity", from, to);
            LastFmAttributesWrapper PlayedTracksAttributes = JsonConvert.DeserializeObject<LastFmAttributesWrapper>(jsonString);

            //If there is more than one song...
            if (PlayedTracksAttributes.Wrapper.Attributes.TotalResults > 1)
            {
                jsonString = await js.InvokeAsync<string>("GetPlayedTracksDuringActivity", from, to);
                this.Activity.PlayedSongs = JsonConvert.DeserializeObject<RecentTracksWrapper>(jsonString);

                //Check if there is a song playing now...
                if (this.Activity.PlayedSongs.TrackList.Tracks.First().TimeData is null)
                {
                    this.Activity.PlayedSongs.TrackList.Tracks.RemoveAt(0);
                }
            }

            if (HasSongs)
            {
                //Switch list to chronological order, returned reversed by API.
                this.Activity.PlayedSongs.TrackList.Tracks.Reverse();
                this.Activity.PlayedSongs.TrackList.Tracks.Insert(0, new() { Name = "Song Not yet played", 
                                                                       TimeData = new() { UnixTimeStamp = 0} 
                                                                      } ) ;

                this.Activity.PlayedSongs.TrackList.Tracks.Insert(this.Activity.PlayedSongs.TrackList.Tracks.Count, new()
                {
                    Name = "No more songs",
                    TimeData = new() { UnixTimeStamp = Double.MaxValue }
                });

                //In order to calculate the polyline index to the timedata for songs
                this.ratio = (to - from) / (this.Activity.PolyLineLength - 1);
                this.BaseTime = from;
                this.UpdateTrackDisplay();
            }


        }

        private async Task UpdateMarker()
        {
            this.SliderValue = await this.js.InvokeAsync<int>("updateTravelMarker", SliderInput);
        }

        private async void UpdateTrackDisplay()
        {
            if (HasSongs)
            {
                double CurrentTime = this.SliderValue * this.ratio + this.BaseTime;

                this.CurrentTrack = this.Activity.PlayedSongs.TrackList.Tracks.Where(t => CurrentTime < t.TimeData.UnixTimeStamp).First();

                if(this.CurrentTrack != this.Activity.PlayedSongs.TrackList.Tracks.First())
                {
                    this.CurrentTrack = this.Activity.PlayedSongs.TrackList.Tracks[this.Activity.PlayedSongs.TrackList.Tracks.IndexOf(this.CurrentTrack) - 1];
                }

                DistanceTraveled = CurrentTime;

                //if (this.CurrentTrack != this.Activity.PlayedSongs.TrackList.Tracks.Last())
                //{
                //    //Detect if Song was not being played at that time
                //    double TrackLength = await this.js.InvokeAsync<double>("GetTrackDuration", this.CurrentTrack.Artist.Name.UrlEncode(), this.CurrentTrack.Name.UrlEncode()) / 1000;
                //    //double NextTrackUTS = this.Activity.PlayedSongs.TrackList.Tracks[this.Activity.PlayedSongs.TrackList.Tracks.IndexOf(this.CurrentTrack) - 1].TimeData.UnixTimeStamp;
                //    DistanceTraveled = CurrentTime + TrackLength;


                //    if (CurrentTime > this.CurrentTrack.TimeData.UnixTimeStamp + TrackLength)
                //    {
                //        this.CurrentTrack = new()
                //        {
                //            Name = "No Song played here.",
                //        };

                //    }

                //}

            }

            //this.DistanceTraveled = await this.js.InvokeAsync<double>("CalculateDistance", SliderInput);

            this.StateHasChanged();

        }
    }
}

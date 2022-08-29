using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Portfolio_Website.Components;
using Portfolio_Website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio_Website.Services;
using Microsoft.Extensions.Options;

namespace Portfolio_Website.Pages
{
    public partial class StravaPage : ComponentBase
    {
        [Inject] IJSRuntime js { get; set; } = default!;

        [Inject] MongoDBService Service { get; set; } = default!;

        [Inject] IOptions<StravaCredentials> Credentials { get; set; } = default!;

        protected List<StravaActivity> activities { get; set; } = new();

        private LoadState DataState { get; set; } = LoadState.Loading;

        private LoadState ButtonState { get; set; } = LoadState.Loading;

        private DetailedStravaActivity DetailedActivity { get; set; } = new();

        DetailedStravaView DetailedStravaView;

        private int PageNumber = 1;

        public async Task UpdateBackend()
        {
            await this.Service.UpdateCollection(this.activities);
        }

        public async Task GetActivities()
        {
            this.ButtonState = LoadState.Loading;
            this.activities.AddRange(await this.Service.GetActivties(this.PageNumber - 1));
            this.activities = this.activities.Where(a => !a.IsPrivate && a.Type == "Run").ToList();
            this.PageNumber++;
            this.ButtonState = LoadState.ValidResults;
        }

        protected override async Task OnAfterRenderAsync(bool FirstRender)
        {
            if (FirstRender) {  
                this.DataState = LoadState.Loading;
                await js.InvokeVoidAsync("SetStravaCredentials", 
                    this.Credentials.Value.ClientId, 
                    this.Credentials.Value.ClientSecret, 
                    this.Credentials.Value.RefreshToken);
                await js.InvokeAsync<string>("GetAuthToken");
                await this.GetActivities();
                this.DataState = LoadState.ValidResults;
                this.StateHasChanged();
            }
        }

        public async Task SetDetailedActivity(StravaActivity activity)
        {
            this.DataState = LoadState.Loading;
            string jsonString = await js.InvokeAsync<string>("GetActivity", activity.Id);
            this.DetailedActivity = JsonConvert.DeserializeObject<DetailedStravaActivity>(jsonString);
            this.DataState = LoadState.ValidResults;
            this.StateHasChanged();
        }

    }
}

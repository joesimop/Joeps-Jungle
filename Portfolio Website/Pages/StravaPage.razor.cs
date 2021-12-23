using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Portfolio_Website.Components;
using Portfolio_Website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Pages
{
    public partial class StravaPage : ComponentBase
    {
        [Inject] IJSRuntime js { get; set; } = default!;

        protected List<StravaActivity> activities { get; set; } = new();

        private LoadState DataState { get; set; } = LoadState.Loading;

        private DetailedStravaActivity DetailedActivity { get; set; } = new();

        DetailedStravaView DetailedStravaView;

        private int PageNumber = 1;

        public async Task GetActivities()
        {
            this.DataState = LoadState.Loading;
            string jsonString = await js.InvokeAsync<string>("GetActivities", this.PageNumber);
            this.activities.AddRange(JsonConvert.DeserializeObject<List<StravaActivity>>(jsonString));
            this.activities = this.activities.Where(a => !a.IsPrivate && a.Type == "Run").ToList();
            this.PageNumber++;
            this.DataState = LoadState.ValidResults;
            this.StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool FirstRender)
        {
            if (FirstRender) { 
                await this.GetActivities();
            }
        }

        public async Task SetDetailedActivity(StravaActivity activity)
        {
            this.DataState = LoadState.Loading;
            string jsonString = await js.InvokeAsync<string>("GetActivity", activity.Id);
            this.DetailedActivity = JsonConvert.DeserializeObject<DetailedStravaActivity>(jsonString);
            this.DataState = LoadState.ValidResults;

            //Implementing this way because the ParameterAsync was being called multiple times, slowing down preformance

            this.StateHasChanged();
        }

    }
}

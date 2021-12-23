using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio_Website.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio_Website.Components
{
    public partial class SplitsBreakdown : ComponentBase
    {

        [Inject] IJSRuntime js { get; set; } = default!;

        [Parameter] public List<StandardSplit> Splits { get; set; }

        private async Task AddMarker(int mileNumber)
        {
            await this.js.InvokeVoidAsync("addMarkerAtMile", mileNumber, this.Splits.Count);
        }

        private async Task RemoveMarker()
        {
            await this.js.InvokeVoidAsync("removeMileMarker");
        }
    }
}

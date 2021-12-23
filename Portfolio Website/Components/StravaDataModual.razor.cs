using Microsoft.AspNetCore.Components;

namespace Portfolio_Website.Components
{
    public partial class StravaDataModual : ComponentBase
    {
        [Parameter] public double DistanceTraveled { get; set; }

        [Parameter] public double SliderInput { get; set; }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Components
{
    public partial class ShortStravaActivity : ComponentBase
    {
        [Parameter] public Data.StravaActivity Activity { get; set; } = new();

        [Parameter] public EventCallback OnClickCallback { get; set; }
    }
}

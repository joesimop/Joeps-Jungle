using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Components
{
    public partial class Card : ComponentBase
    {
        [Parameter] public string Title { get; set; } = string.Empty!;
        [Parameter] public RenderFragment CustomTitle { get; set; } = default!;
        [Parameter] public RenderFragment Content { get; set; } = default!;
        [Parameter] public RenderFragment Footer { get; set; } = default!;

        [Parameter(CaptureUnmatchedValues =true)] 
        public Dictionary<string, object> InputAttributes { get; set; } = default!;

        [Parameter] public string CardClass { get; set; } = string.Empty!;
        [Parameter] public string FooterClass { get; set; } = string.Empty!;
        [Parameter] public bool RemovePadding { get; set; }

    }
}


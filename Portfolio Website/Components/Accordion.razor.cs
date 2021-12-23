using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Components
{
    public partial class Accordion : ComponentBase
    {
        [Parameter] public string Id { get; init; } = string.Empty!;

        [Parameter] public RenderFragment Trigger { get; init; } = default!;

        [Parameter] public RenderFragment Extra { get; init; } = default!;
    }
}

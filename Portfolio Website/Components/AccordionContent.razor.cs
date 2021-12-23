using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Components
{
    public partial class AccordionContent : ComponentBase
    {
        [Parameter] public string Id { get; init; } = string.Empty!;
        [Parameter] public string Target { get; init; } = "ProjectsAccordion";

        [Parameter] public RenderFragment ChildContent { get; init; } = default!;
    }
}

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio_Website.Components
{
    public partial class Grid<TItem> : ComponentBase
    {
        [Parameter] public IReadOnlyList<TItem> DataSource { get; set; } = default;

        [Parameter] public RenderFragment<TItem> CoordinateContent { get; set; } = default!;

        [Parameter] public int MaxItemsPerRow { get; set; } = 1;

        [Parameter] public bool Gutters { get; set; }

        private int NumberOfItems { get; set; }

        private int NumberOfRows { get; set; }

        protected override void OnParametersSet()
        {
            this.NumberOfItems = this.DataSource.Count();
            this.NumberOfRows = (this.NumberOfItems + this.MaxItemsPerRow - 1) / this.MaxItemsPerRow;

        }
    }
}


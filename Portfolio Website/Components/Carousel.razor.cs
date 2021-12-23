using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Portfolio_Website.Components
{
    public partial class Carousel : ComponentBase
    {
        [Parameter] public List<(string, string, string)> ImageData { get; set; } = new();

        [Parameter] public string Id { get; set; } = string.Empty;

        private int SelectedImage { get; set; }

        private void NextImage()
        {
            this.SelectedImage = (++this.SelectedImage) % this.ImageData.Count;
        }

        private void PreviousImage()
        {
            if(this.SelectedImage == 0)
            {
                this.SelectedImage = this.ImageData.Count-1;
            }
            else
            {
                this.SelectedImage--;
            }
        }
    }
}

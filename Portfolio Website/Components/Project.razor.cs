using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Website.Components
{
    public partial class Project : ComponentBase
    {
        [Parameter] public string Title { get; set; } = string.Empty!;

        [Parameter] public string GitLink { get; set; } = string.Empty!;
        [Parameter] public RenderFragment Description { get; set; } = default!;

        private bool HasGithub => this.GitLink != string.Empty;

        private string Id { get; set; } = string.Empty!;

        protected override void OnInitialized()
        {
            //Generate a "random" seed for each accordion
            Random generator = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            this.Id = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[generator.Next(s.Length)]).ToArray());
        }
    }

}

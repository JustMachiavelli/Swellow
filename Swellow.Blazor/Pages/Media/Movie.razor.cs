
using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Pages.Media
{
    public partial class Movie
    {
        [Inject] public IServer Server { get; set; }

        [Parameter] public string MovieId { get; set; }

        public MovieDetail MovieDetail { get; set; } = new MovieDetail();

        protected override async Task OnInitializedAsync()
        {
            MovieDetail = await Server.GetMovieDetailByMovieIdAsync(MovieId);
            await base.OnInitializedAsync();
        }
    }
}

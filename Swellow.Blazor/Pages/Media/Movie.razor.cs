
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

        //1 电影ID【跳传】
        [Parameter] public string MovieId { get; set; }

        //2 电影详情【后传】
        public MovieDetail MovieDetail { get; set; } = new MovieDetail();


        //【生命】
        protected override async Task OnInitializedAsync()
        {
            MovieDetail = await Server.GetMovieDetailByMovieIdAsync(MovieId);
        }
    }
}

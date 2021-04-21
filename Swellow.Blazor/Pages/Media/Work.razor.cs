using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Swellow.Blazor.Services;
using Swellow.Shared.Dto.Metadata.Media;
using Swellow.Shared.Dto.Metadata.Property;
using Swellow.Shared.Dto.Metadata.Person;
using System.Collections.Generic;
using System.Linq;
using Swellow.Shared.Dto.Metadata.Media.Television;
using Swellow.Shared.Dto.Metadata.Media.Film;

namespace Swellow.Blazor.Pages.Media
{
    public partial class Work
    {
        [Inject] public MediaService MediaService { get; set; }


        //1 媒体库ID【url传】
        [Parameter] public int LibraryId { get; set; }


        //2 电影ID【url传】
        [Parameter] public int WorkId { get; set; }


        //3 电影详情【后传】
        public WorkDetail WorkDetail { get; set; } = new WorkDetail();

        //4 Genres
        public IEnumerable<GenrePreview> Genres { get; set; } = Enumerable.Empty<GenrePreview>();

        //5 Casts
        public IEnumerable<CastPreview> Casts { get; set; } = Enumerable.Empty<CastPreview>();


        //6 Casts
        public IEnumerable<SeasonPreview> Seasons { get; set; } = Enumerable.Empty<SeasonPreview>();


        //7 Casts
        public IEnumerable<MoviePreview> Movies { get; set; } = Enumerable.Empty<MoviePreview>();


        //【生命】
        protected override async Task OnInitializedAsync()
        {
            WorkDetail = await MediaService.GetWorkDetailByIdAsync(WorkId);
            Genres = await MediaService.GetGenrePreviewsAsync(WorkId) ?? Enumerable.Empty<GenrePreview>();
            Casts = await MediaService.GetCastPreviewsAsync(WorkId) ?? Enumerable.Empty<CastPreview>();
            Seasons = await MediaService.GetSeasonPreviewsAsync(WorkId) ?? Enumerable.Empty<SeasonPreview>();
            Movies = await MediaService.GetMoviePreviewsAsync(WorkId) ?? Enumerable.Empty<MoviePreview>();

        }

        protected override void OnAfterRender(bool firstRender=false)
        {
            System.Console.WriteLine("Render完毕！");
        }
    }
}

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
        #region http服务
        [Inject] public MediaService MediaService { get; set; }
        #endregion


        #region url传参
        //1 媒体库ID
        [Parameter] public int LibraryId { get; set; }
        //2 电影ID
        [Parameter] public int WorkId { get; set; }
        #endregion


        #region 后端获取
        //3 电影详情
        public WorkDetail WorkDetail { get; set; } = new WorkDetail();
        //4 Genres
        public IEnumerable<GenrePreview> Genres { get; set; } = Enumerable.Empty<GenrePreview>();
        //5 Casts
        public IEnumerable<CastPreview> Casts { get; set; } = Enumerable.Empty<CastPreview>();
        //6 Casts
        public IEnumerable<SeasonPreview> Seasons { get; set; } = Enumerable.Empty<SeasonPreview>();
        //7 Casts
        public IEnumerable<MoviePreview> Movies { get; set; } = Enumerable.Empty<MoviePreview>();
        #endregion


        #region 生命周期
        protected override async Task OnInitializedAsync()
        {
            var workTask = MediaService.GetWorkDetailByIdAsync(WorkId);
            var genresTask = MediaService.GetGenrePreviewsAsync(WorkId);
            var castsTask = MediaService.GetCastPreviewsAsync(WorkId);
            var seasonsTask = MediaService.GetSeasonPreviewsAsync(WorkId);
            var moviesTask = MediaService.GetMoviePreviewsAsync(WorkId);
            await Task.WhenAll(workTask, genresTask, castsTask, seasonsTask, moviesTask);
            WorkDetail = await workTask ?? new WorkDetail();
            Genres = (await genresTask) ?? Enumerable.Empty<GenrePreview>();
            Casts = (await castsTask) ?? Enumerable.Empty<CastPreview>();
            Seasons = (await seasonsTask) ?? Enumerable.Empty<SeasonPreview>();
            Movies = (await moviesTask) ?? Enumerable.Empty<MoviePreview>();
        }

        protected override void OnAfterRender(bool firstRender=false)
        {
            System.Console.WriteLine("Render完毕！");
        }
        #endregion
    }
}

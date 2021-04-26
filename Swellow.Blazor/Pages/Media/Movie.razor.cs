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
    public partial class Movie
    {
        #region http服务
        [Inject] public MediaService MediaService { get; set; }
        #endregion


        #region url传参
        //1 媒体库ID
        [Parameter] public int LibraryId { get; set; }
        //2 电影ID
        [Parameter] public int WorkId { get; set; }
        //3 媒体库ID
        [Parameter] public int MovieId { get; set; }
        #endregion


        #region 后端获取
        //3 电影详情
        public MovieDetail MovieDetail { get; set; } = new MovieDetail();
        #endregion


        #region 生命周期
        protected override async Task OnInitializedAsync()
        {
            MovieDetail = await MediaService.GetMovieDetailByIdAsync(MovieId);
        }

        protected override void OnAfterRender(bool firstRender = false)
        {
            System.Console.WriteLine("Render完毕！");
        }
        #endregion
    }
}

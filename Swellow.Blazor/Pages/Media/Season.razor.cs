using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Shared.Dto.Metadata.Media.Television;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Pages.Media
{
    public partial class Season
    {
        #region http服务
        [Inject] public MediaService MediaService { get; set; }
        #endregion


        #region url传参
        //1 媒体库ID
        [Parameter] public int LibraryId { get; set; }
        //2 电影ID
        [Parameter] public int WorkId { get; set; }
        //1 媒体库ID
        [Parameter] public int SeasonId { get; set; }
        #endregion


        #region 后端获取
        //3 电影详情
        public SeasonDetail SeasonDetail { get; set; } = new SeasonDetail();
        //4 Genres
        public IEnumerable<EpisodePreview> EpisodePreviews { get; set; } = Enumerable.Empty<EpisodePreview>();
        #endregion


        #region 生命周期
        protected override async Task OnInitializedAsync()
        {
            Task<SeasonDetail> seasonTask = MediaService.GetSeasonDetailAsync(SeasonId);
            Task<IEnumerable<EpisodePreview>> episodeTask = MediaService.GetEpisodePreviewsAsync(SeasonId);
            await Task.WhenAll(seasonTask, episodeTask);
            SeasonDetail = await seasonTask;
            EpisodePreviews = (await episodeTask) ?? Enumerable.Empty<EpisodePreview>();
        }

        protected override void OnAfterRender(bool firstRender = false)
        {
            System.Console.WriteLine("Render完毕！");
        }
        #endregion
    }
}

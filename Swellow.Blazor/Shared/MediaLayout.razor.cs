using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Swellow.Blazor.Services;
using System;

namespace Swellow.Blazor.Shared
{
    public partial class MediaLayout
    {
        [Inject] public ILibraryService LibraryService { get; set; }
        [Inject] public IVideoService VideoService { get; set; }

        public int LibraryId { get; set; }
        public string LibraryName { get; set; }
        public int VideoId { get; set; }
        public string VideoName { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine("正在OnParametersSetAsync");
            object id = null;
            // URL包含Library
            if ((Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("LibraryId", out id) == true)
            {
                LibraryId = Convert.ToInt32(id);
                LibraryName = await LibraryService.GetLibraryNameAsync(LibraryId);
                // URL在Video
                if ((Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("MovieId", out id) == true | (Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("TvId", out id) == true)
                {
                    VideoId = Convert.ToInt32(id);
                    VideoName = await VideoService.GetVideoNameAsync(VideoId);
                }
                // URL在Library
                else
                {
                    VideoName = null;
                }
            }
            // URL在Home
            else
            {
                LibraryName = null;
                VideoName = null;
            }

        }
    }
}

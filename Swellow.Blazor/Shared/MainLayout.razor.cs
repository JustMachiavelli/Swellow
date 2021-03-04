using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using BootstrapBlazor.Components;
using System.Threading.Tasks;
using Swellow.Blazor.Services;
using System;

namespace Swellow.Blazor.Shared
{
    public partial class MainLayout
    {
        [Inject] public IServer Server { get; set; }

        [Parameter] public IList<BreadcrumbItem> BreadcrumbUrl { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            string LibraryName = null;
            string VideoName = null;
            object id = null;

            if ((Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("LibraryId", out id) == true)
            {
                LibraryName = await Server.GetLibraryNameByLibraryIdAsync(Convert.ToInt32(id));
            }

            if ((Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("VideoId", out id) == true)
            {
                VideoName = await Server.GetVideoNameByVideoIdAsync(Convert.ToInt32(id));
            }


            BreadcrumbUrl = new List<BreadcrumbItem>();

            // 有媒体库
            if (!string.IsNullOrEmpty(LibraryName))
            {
                BreadcrumbUrl.Add(new BreadcrumbItem("主页", "/"));
                // 有影视剧，在Video.razor
                if (!string.IsNullOrEmpty(VideoName))
                {
                    BreadcrumbUrl.Add(new BreadcrumbItem(LibraryName, "/Library/{LibraryId}"));
                    BreadcrumbUrl.Add(new BreadcrumbItem(VideoName, "/Library/{LibraryId}/Movie/{MovieId}"));
                }
                // 没影视剧，在Library.razor
                else
                {
                    BreadcrumbUrl.Add(new BreadcrumbItem(LibraryName));
                }
            }
            // 没媒体库，在Home.razor
            else
            {
                BreadcrumbUrl.Add(new BreadcrumbItem("主页"));
            }
        }
    }
}

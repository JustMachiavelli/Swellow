using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Model.ViewModel;

namespace Swellow.Blazor.Pages.Media
{
    public partial class Library
    {
        [Inject] public IServer Server { get; set; }


        //1 媒体库ID【跳传】
        [Parameter] public string LibraryId { get; set; }


        //2 媒体库名称【后传】
        private string LibraryName { get; set; }


        //3 所含影视剧预览【后传】
        private IEnumerable<VideoPreview> VideoPreviews { get; set; } = new List<VideoPreview>();


        //【生命】
        protected override async Task OnInitializedAsync()
        {
            LibraryName = await Server.GetLibraryNameByLibraryIdAsync(LibraryId);
            VideoPreviews = await Server.GetVideoPreviewsByLibraryIdAsync(LibraryId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Model.ViewModel;

namespace Swellow.Blazor.Pages.Media
{
    public partial class Library
    {
        [Inject] public IServer Server { get; set; }

        [Parameter] public string LibraryId { get; set; }

        public string LibraryName { get; set; }

        public IEnumerable<VideoPreview> VideoPreviews { get; set; } = new List<VideoPreview>();

        protected override async Task OnInitializedAsync()
        {
            LibraryName = await Server.GetLibraryNameByLibraryIdAsync(LibraryId);
            VideoPreviews = await Server.GetVideoPreviewsByLibraryIdAsync(LibraryId);
            await base.OnInitializedAsync();
        }
    }
}

using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Model.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swellow.Blazor.Pages.Media
{
    public partial class Home
    {
        [Inject] public IServer Server { get; set; }


        //1 所有媒体库预览【后传】
        private IEnumerable<LibraryPreview> LibraryPreviews { get; set; } = new List<LibraryPreview>();


        //【生命】
        protected override async Task OnInitializedAsync()
        {
            LibraryPreviews = await Server.GetLibraryPreviewsAsync();
            await base.OnInitializedAsync();
        }
    }
}

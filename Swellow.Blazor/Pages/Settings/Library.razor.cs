using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Model.Enum;
using Swellow.Model.ViewModel.Media;
using Swellow.Model.ViewModel.Settings;


namespace Swellow.Blazor.Pages.Settings
{
    public partial class Library
    {
        [Inject] public IServer Server { get; set; }


        //1 所有Library预览【后传】
        private IEnumerable<LibraryPreview> LibraryPreviews { get; set; } = new List<LibraryPreview>();


        public LibraryCreateEdit NewLibrary { get; set; }

        //【OnInitialized】
        protected override async Task OnInitializedAsync()
        {
            NewLibrary = new LibraryCreateEdit
            {
                Name = "",
                Type = LibraryType.Movie,
            };
            LibraryPreviews = await Server.GetLibraryPreviewsAsync();
            await base.OnInitializedAsync();
        }

        private Task HandleValidSubmit()
        {
            return Task.CompletedTask;
        }

        private void HandleInvalidSubmit()
        {
            System.Console.WriteLine("正在HandleInvalidSubmit");
        }
    }
}

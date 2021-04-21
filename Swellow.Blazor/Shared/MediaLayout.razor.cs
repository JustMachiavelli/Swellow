using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Swellow.Blazor.Services;
using System;

namespace Swellow.Blazor.Shared
{
    public partial class MediaLayout
    {
        [Inject] public LibraryService LibraryService { get; set; }
        [Inject] public MediaService MediaService { get; set; }

        public int LibraryId { get; set; }
        public string LibraryName { get; set; }
        public int WorkId { get; set; }
        public string WorkName { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine("正在OnParametersSetAsync");
            object id = null;
            // URL包含Library
            if ((Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("LibraryId", out id) == true)
            {
                LibraryId = Convert.ToInt32(id);
                LibraryName = await LibraryService.GetLibraryNameAsync(LibraryId);
                // URL在Work
                if ((Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("WorkId", out id) == true)
                {
                    WorkId = Convert.ToInt32(id);
                    WorkName = await MediaService.GetWorkNameAsync(WorkId);
                }
                // URL在Library
                else
                {
                    WorkName = null;
                }
            }
            // URL在Home
            else
            {
                LibraryName = null;
                WorkName = null;
            }

        }
    }
}

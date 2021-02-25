using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Pages.Media
{
    public partial class Home
    {

        private IEnumerable<LibraryPreview> LibraryPreviews { get; set; } = new List<LibraryPreview>();

        public class LibraryPreview
        {
            // 媒体库的编号
            public int Id { get; set; }

            // 媒体库的名称
            public string Name { get; set; }

            // 媒体库的预览图路径
            public string PathPicture { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            LibraryPreviews = new List<LibraryPreview>
            {
                new LibraryPreview()
                {
                    Id = 1,
                    Name = "动漫Movie",
                    PathPicture = "https://ss2.bdstatic.com/70cFvnSh_Q1YnxGkpoWK1HF6hhy/it/u=2711030845,3469585955&fm=26&gp=0.jpg",
                },
                new LibraryPreview()
                {
                    Id = 2,
                    Name = "动漫Tv",
                    PathPicture = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=3657906999,2769279656&fm=26&gp=0.jpg",
                }
            };
            await base.OnInitializedAsync();
        }
    }
}

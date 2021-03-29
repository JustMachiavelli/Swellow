using Swellow.Model.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public class MockLibraryService:ILibraryService
    {
        public async Task<IEnumerable<LibraryPreview>> GetLibraryPreviewsAsync()
        {
            return await Task.Run(() => {
                return new List<LibraryPreview>
                {
                    new LibraryPreview()
                    {
                        Id = 1,
                        Name = "科幻电影",
                        Fanart = "/SwellowData/Images/Library/preview/1.jpg",
                    },
                    new LibraryPreview()
                    {
                        Id = 2,
                        Name = "动漫Tv",
                        Fanart = "/SwellowData/Images/Library/preview/2.jpg",
                    }
                };
            });
        }


        public async Task<string> GetLibraryNameAsync(int libraryId)
        {
            return await Task.Run(() => {
                return "科幻电影";
            });
        }
    }
}

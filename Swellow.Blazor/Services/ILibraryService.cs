using Swellow.Model.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public interface ILibraryService
    {
        //1 得到所有Library预览
        Task<IEnumerable<LibraryPreview>> GetLibraryPreviewsAsync();

        //2 依据libraryId得到LibraryName
        Task<string> GetLibraryNameAsync(int libraryId);
    }
}

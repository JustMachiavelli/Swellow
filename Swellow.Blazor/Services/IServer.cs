using Swellow.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public interface IServer
    {
        //1 得到所有媒体库的预览，用于“主页”的展示
        Task<IEnumerable<LibraryPreview>> GetLibraryPreviewsAsync();
        Task<IEnumerable<VideoPreview>> GetVideoPreviewsByLibraryIdAsync(string libraryId);
        Task<string> GetLibraryNameByLibraryIdAsync(string libraryId);
        Task<MovieDetail> GetMovieDetailByMovieIdAsync(string movieId);
    }
}

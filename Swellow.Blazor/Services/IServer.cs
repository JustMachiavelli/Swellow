using Swellow.Model.ViewModel.Dto;
using Swellow.Model.ViewModel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public interface IServer
    {
        //1 得到所有Library预览
        Task<IEnumerable<LibraryPreview>> GetLibraryPreviewsAsync();


        //2 依据libraryId得到所有Video预览
        Task<IEnumerable<VideoPreview>> GetVideoPreviewsByLibraryIdAsync(int libraryId);


        //3 依据libraryId得到LibraryName
        Task<string> GetLibraryNameByLibraryIdAsync(int libraryId);


        //4 依据movieId得到Media.Video.page包含的Move.cpt需要的Movie详情
        Task<MovieViewModel> GetMovieDetailByMovieIdAsync(int movieId);


        //5 依据videoId得到VideoName
        Task<string> GetVideoNameByVideoIdAsync(int videoId);
    }
}

using Swellow.Shared.ViewModel.Dto;
using Swellow.Shared.ViewModel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public interface IVideoService
    {

        //2 依据libraryId得到所有Video预览
        Task<IEnumerable<VideoPreview>> GetVideoPreviewsAsync(int libraryId);


        //4 依据movieId得到Media.Video.page包含的Move.cpt需要的Movie详情
        Task<MovieDetail> GetMovieDetailAsync(int movieId);


        //5 依据videoId得到VideoName
        Task<string> GetVideoNameAsync(int videoId);
    }
}

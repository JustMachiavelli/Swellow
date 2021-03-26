using Swellow.Model.ViewModel.Dto;
using Swellow.Model.ViewModel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public class ApiServer : IServer
    {
        public Task<string> GetLibraryNameByLibraryIdAsync(int libraryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LibraryPreview>> GetLibraryPreviewsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MovieViewModel> GetMovieDetailByMovieIdAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetVideoNameByVideoIdAsync(int videoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoPreview>> GetVideoPreviewsByLibraryIdAsync(int libraryId)
        {
            throw new NotImplementedException();
        }
    }
}

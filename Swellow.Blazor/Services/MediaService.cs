using Swellow.Shared.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public class MediaService
    {
        private readonly HttpClient _httpClient;

        public MediaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // 得到所有LibraryPreview
        public async Task<IEnumerable<LibraryPreview>> GetLibraryPreviewsAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<LibraryPreview>>(
                await _httpClient.GetStreamAsync("api/library/previews"),
                new JsonSerializerOptions
                {
                    // 是 区分大小写
                    PropertyNameCaseInsensitive = true
                });
        }


        // 得到一个Library的Name依据LibraryId
        public async Task<string> GetLibraryNameAsync(int id)
        {
            return await _httpClient.GetStringAsync($"api/library/{id}/name");
        }


        // 得到WorkPreviews依据libraryId
        public async Task<IEnumerable<WorkPreview>> GetWorkPreviewsAsync(int libraryId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<WorkPreview>>(
                await _httpClient.GetStreamAsync($"api/library/{libraryId}/works"),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }



        public async Task<Work> GetMovieDetailAsync(int movieId)
        {

        }

        public async Task<string> GetVideoNameAsync(int videoId)
        {

        }
    }
}
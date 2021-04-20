using Swellow.Shared.Dto.Metadata.Media;
using Swellow.Shared.Dto.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public class LibraryService
    {
        private readonly HttpClient _httpClient;

        public LibraryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        // 1 得到所有LibraryPreview
        public async Task<IEnumerable<LibraryPreview>> GetAllLibraryPreviewsAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<LibraryPreview>>(
                await _httpClient.GetStreamAsync("api/library/previews"),
                new JsonSerializerOptions
                {
                    // 是 区分大小写
                    PropertyNameCaseInsensitive = true
                });
        }


        // 2 得到一个Library的Name依据LibraryId
        public async Task<string> GetLibraryNameAsync(int id)
        {
            return await _httpClient.GetStringAsync($"api/library/{id}/name");
        }


        // 3 得到WorkPreviews依据libraryId
        public async Task<IEnumerable<WorkPreview>> GetWorkPreviewsByLibraryIdAsync(int libraryId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<WorkPreview>>(
                await _httpClient.GetStreamAsync($"api/library/{libraryId}/workPreviews"),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}

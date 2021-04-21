using Swellow.Shared.Dto.Metadata.Media;
using Swellow.Shared.Dto.Metadata.Media.Film;
using Swellow.Shared.Dto.Metadata.Media.Television;
using Swellow.Shared.Dto.Metadata.Person;
using Swellow.Shared.Dto.Metadata.Property;
using System;
using System.Collections.Generic;
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

        // 1 依据WorkId得到WorkDetail
        public async Task<WorkDetail> GetWorkDetailByIdAsync(int workId)
        {
            WorkDetail workDetail = await JsonSerializer.DeserializeAsync<WorkDetail>(
                await _httpClient.GetStreamAsync($"api/work/{workId}/workDetail"),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            return workDetail;
        }


        // 2 依据Work Id获取SeasonPreviews
        public async Task<IEnumerable<SeasonPreview>> GetSeasonPreviewsAsync(int workId)
        {
            IEnumerable<SeasonPreview> seasonPreviews = await JsonSerializer.DeserializeAsync<IEnumerable<SeasonPreview>>(
                await _httpClient.GetStreamAsync($"api/work/{workId}/seasonPreviews"),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            return seasonPreviews;
        }


        // 3 依据Work Id获取MoviePreviews
        public async Task<IEnumerable<MoviePreview>> GetMoviePreviewsAsync(int workId)
        {
            IEnumerable<MoviePreview> moviePreviews = await JsonSerializer.DeserializeAsync<IEnumerable<MoviePreview>>(
                await _httpClient.GetStreamAsync($"api/work/{workId}/moviePreviews"),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            return moviePreviews;
        }


        // 4 依据Work Id获取MoviePreviews
        public async Task<IEnumerable<GenrePreview>> GetGenrePreviewsAsync(int workId)
        {
            IEnumerable<GenrePreview> genrePreviews = await JsonSerializer.DeserializeAsync<IEnumerable<GenrePreview>>(
                await _httpClient.GetStreamAsync($"api/work/{workId}/genres"),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            return genrePreviews;
        }


        // 5 依据Work Id获取CastPreviews
        public async Task<IEnumerable<CastPreview>> GetCastPreviewsAsync(int workId)
        {
            IEnumerable<CastPreview> genrePreviews = await JsonSerializer.DeserializeAsync<IEnumerable<CastPreview>>(
                await _httpClient.GetStreamAsync($"api/work/{workId}/casts"),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            return genrePreviews;
        }


        // 6  依据Work Id获取Work Name
        internal async Task<string> GetWorkNameAsync(int workId)
        {
            return await _httpClient.GetStringAsync($"api/work/{workId}/name");
        }
    }
}
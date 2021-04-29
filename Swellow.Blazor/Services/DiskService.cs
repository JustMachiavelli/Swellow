using Swellow.Shared.Dto.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public class DiskService
    {
        private readonly HttpClient _httpClient;

        public DiskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // 1 获取主机名
        public async Task<string> GetHostName()
        {
            return await _httpClient.GetStringAsync($"api/environment/host/name");
        }

        internal DirectoryDetail GetDirectoryDetailAsync(string empty)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<DirectoryDetail> GetSubDirectorysAsync(string path)
        {
            throw new NotImplementedException();
        }

        // 2 获取所有磁盘 DriveInfo[] driveInfos
        public async Task<IEnumerable<DriveInfo>> GetDiskPreviewsAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<DriveInfo>>(
                await _httpClient.GetStreamAsync("api/environment/diskPreviews"),
                new JsonSerializerOptions
                {
                    // 是 区分大小写
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}

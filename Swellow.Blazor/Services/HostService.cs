using Swellow.Shared.Dto.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swellow.Blazor.Services
{
    public class HostService
    {
        private readonly HttpClient _httpClient;

        public HostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // 1 获取所有磁盘 DriveInfo[] driveInfos
        public async Task<IEnumerable<string>> GetDrivesAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<string>>(
                await _httpClient.GetStreamAsync("api/host/drives"),
                new JsonSerializerOptions
                {
                    // 是 区分大小写
                    PropertyNameCaseInsensitive = true
                });
        }

        // 2 依据目录path获取当前目录的相关情况
        internal async Task<DirectoryDetail> GetDirectoryDetailAsync(string path)
        {
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(path), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("api/host/directory/detail", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<DirectoryDetail>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }
    }
}

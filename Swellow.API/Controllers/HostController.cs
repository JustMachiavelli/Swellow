using Microsoft.AspNetCore.Mvc;
using Swellow.LocalHost;
using Swellow.Shared.Dto.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Controllers
{
    [ApiController]
    public class HostController : ControllerBase
    {
        // 0 获取主机名
        [HttpGet("api/host/name")]
        public async Task<string> GetHostName()
        {
            return await FileExplorer.GetHostName();
        }

        // 1 获取所有磁盘 IEnumerable<string> driveInfos
        [HttpGet("api/host/drives")]
        public IEnumerable<string> GetDrivesAsync()
        {
            IEnumerable<string> drives = FileExplorer.GetDrives();
            return drives;
        }

        // 2 依据目录path获取当前目录的相关情况
        [HttpPost("api/host/directory/detail")]
        public async Task<DirectoryDetail> GetDirectoryDetailAsync([FromBody]string path)
        {
            DirectoryDetail directory = new()
            {
                Path = path,
                ParentPath = await FileExplorer.GetParentPathAsync(path),
                SubFolders = await FileExplorer.GetSubFolders(path),
            };
            return directory;
        }

    }
}

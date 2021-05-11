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
        public string GetHostName()
        {
            return FileExplorer.GetHostName();
        }

        // 1 获取所有磁盘 IEnumerable<string> driveInfos
        [HttpGet("api/host/drives")]
        public IEnumerable<string> GetDrives()
        {
            return FileExplorer.GetDrives();
        }

        // 2 依据 当前目录path 获取当前目录的相关情况
        [HttpPost("api/host/directory/detail")]
        public DirectoryDetail GetDirectoryDetail([FromBody]string path)
        {
            return new DirectoryDetail()
            {
                ParentPath = FileExplorer.GetParentPathAsync(path),
                Path = path,
                SubFolders = FileExplorer.GetSubFolders(path),
            };
        }

    }
}

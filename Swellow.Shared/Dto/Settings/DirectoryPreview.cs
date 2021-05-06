using System.Collections.Generic;

namespace Swellow.Shared.Dto.Settings
{
    public class DirectoryDetail
    {
        //public string? Name { get; set; }

        public string? Path { get; set; } = "测试";

        public string? ParentPath { get; set; } = "测试";

        public IEnumerable<string>? SubFolders { get; set; } = new List<string>();

    }
}
using System.Collections.Generic;

namespace Swellow.Shared.Dto.Settings
{
    public class DirectoryDetail
    {
        //public string? Name { get; set; }

        // 默认值 表示 在“我的电脑下的磁盘预览”
        public string? ParentPath { get; set; } = null;

        public string? Path { get; set; } = string.Empty;

        public IEnumerable<string>? SubFolders { get; set; } = new List<string>();

    }
}
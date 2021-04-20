using Swellow.Shared.Environment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Swellow.Shared.Dto.View
{
    public class LibraryPreview
    {
        // 媒体库的编号
        public int Id { get; set; }


        // 媒体库的名称
        public string? Name { get; set; }


        // 媒体库的预览图路径 = StaticFiles.LibraryDefaultFanartPath;
        public string? Fanart { get; set; }
    }
}

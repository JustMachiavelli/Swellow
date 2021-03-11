using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Model.ViewModel.Media
{
    public class LibraryPreview
    {
        // 媒体库的编号
        public int Id { get; set; }

        // 媒体库的名称
        public string Name { get; set; }

        // 媒体库的预览图路径
        public string PathImage { get; set; }
    }
}

using Swellow.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Model.SqlModel.Appendages
{
    public class Subtitle
    {
        // 1 字幕类型
        public SubtitleType Type { get; set; }

        // 2 字幕组名称
        public string Fansub { get; set; }

    }
}

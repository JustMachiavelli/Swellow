﻿using Swellow.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Shared.ViewModel.Dto
{
    public class WorkPreview
    {
        // 0 影视ID
        public int Id { set; get; }
        // 1 影视标题
        public string? Display { set; get; }
        // 2 海报路径 静态文件相对路径
        //public string? Directory { set; get; }
        // 3 发行年份
        public int? Year { set; get; }
        public int? EndYear { get; set; }
        // 4 影视类别
        public WorkType Type { set; get; } = WorkType.Mix;
    }
}

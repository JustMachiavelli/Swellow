using Swellow.Shared.Enum;
using Swellow.Shared.Environment;

namespace Swellow.Shared.ViewModel.Dto
{
    public class WorkPreview
    {
        // 0 影视ID
        public int Id { set; get; }


        // 1 影视类别
        public WorkType Type { set; get; } = WorkType.Mix;


        // 2 标题
        public string? Display { set; get; }


        // 4 发行年份
        public int? Year { set; get; }


        // 5 剧终年份
        public int? EndYear { get; set; }


        // 6 评分
        public byte Score { get; set; }


        // 11 所在文件夹【相对路径】
        public string? Directory { get; set; }


        // 6 Fanart
        public string? Fanart { get; set; }


    }
}

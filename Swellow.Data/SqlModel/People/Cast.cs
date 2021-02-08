using Swellow.Data.SqlModel.Middle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Swellow.Data.SqlModel.People
{
    // 演职人员
    public class Cast
    {
        public Cast()
        {
            VideoActors = new List<VideoActor>();
            VideoDirectors = new List<VideoDirector>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 演职人员类别
        public string Type { get; set; }

        // 2 名字
        public string Name { get; set; }

        // 3 名字原始
        public string NameOriginal { get; set; }

        // 4 曾用名字
        public string NameOld { get; set; }

        // 5 照片路径
        public string PathHeadPicture
        {
            get
            {
                string pathRelative = "/images/cast/" + Name[0] + "/" + Name[^1] + "/" + Name + ".jpg";
                string pathAbsolute = Environment.LocalPath.PathRoot + pathRelative;
                if (File.Exists(pathAbsolute))
                {
                    return "/swellowdata" + pathRelative; ;
                }
                else
                {
                    return "/images/default/nobody.svg";
                }
            }
        }

        // 6【集合导航】【中间件】<影视作品，演员>
        public List<VideoActor> VideoActors { get; set; }

        // 7【集合导航】【中间件】<影视作品，导演>
        public List<VideoDirector> VideoDirectors { get; set; }
    }
}

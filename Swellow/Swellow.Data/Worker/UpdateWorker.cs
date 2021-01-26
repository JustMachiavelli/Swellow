using Swellow.Data.SqlModel.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Data.Worker
{
    public class UpdateWorker
    {
        private readonly SwellowDbContext _context;

        public UpdateWorker(SwellowDbContext context)
        {
            _context = context;
        }

        public void UpdateVideoPicture()
        {
            foreach (Video video in _context.Videos)
            {
                string pathFanartRelative = "/swellowdata/images/movie/" + video.TitleOriginZh[0] + "/" + video.TitleOrigin[^1] + "/" + video.TitleOrigin + "(" + video.Year + ")/fanart.jpg";
                string pathFanartAbsolute = Environment.LocalPath.PathRoot + pathFanartRelative;
                bool isFanartExist = System.IO.File.Exists(pathFanartAbsolute);
                // 目前数据库内不是默认svg
                if (video.PathFanart != "/images/default/novideofanart.svg")
                {
                    // 数据库记录的图片不存在
                    if (!isFanartExist)
                    {
                        video.PathFanart = "/images/default/novideofanart.svg";
                    }
                    // 如果存在，保持原样
                }
                // 数据库里记录是默认svg
                else
                {
                    if (isFanartExist)
                    {
                        video.PathFanart = pathFanartRelative;
                    }
                }

                string pathPosterRelative = "/swellowdata/images/movie/" + video.TitleOriginZh[0] + "/" + video.TitleOriginZh[^1] + "/" + video.TitleOriginZh + "(" + video.Year + ")/poster.jpg";
                string pathPosterAbsolute = Environment.LocalPath.PathRoot + pathPosterRelative;
                bool isPosterExist = System.IO.File.Exists(pathPosterAbsolute);
                // 目前数据库内不是默认svg
                if (video.PathPoster != "/images/default/novideoposter.svg")
                {
                    // 数据库记录的图片不存在
                    if (!isPosterExist)
                    {
                        video.PathPoster = "/images/default/novideoposter.svg";
                    }
                    // 如果存在，保持原样
                }
                // 数据库里记录是默认svg
                else
                {
                    if (isPosterExist)
                    {
                        video.PathPoster = pathPosterRelative;
                    }
                }
            }
            _context.SaveChanges();
        }
    }
}

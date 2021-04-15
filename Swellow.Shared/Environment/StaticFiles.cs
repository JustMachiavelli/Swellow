
namespace Swellow.Shared.Environment
{
    //【相对路径】
    public class StaticFiles
    {
        #region 默认图片
        public const string DefaultDirectory = "/default";

        // 默认Library图片
        public const string LibraryDefaultFanart = "/default/library-fanart.svg";
        // 默认Person的poster
        public const string PersonDefaultPoster = "/default/person-poster.svg";

        // 默认Work文件夹
        public const string WorkDefaultDirectory = DefaultDirectory + "/默认影视(1900)";
        // 默认Work Fanart
        public const string WorkDefaultFanart = WorkDefaultDirectory + "/fanart.jpg";
        // 默认Work Poster
        public const string WorkDefaultPoster = WorkDefaultDirectory + "/poster.jpg";

        // 默认Work Season文件夹
        public const string SeasonDefaultDirectory = WorkDefaultDirectory + "/S00 - Y1900";
        // 默认Season Poster
        public const string SeasonDefaultPoster = SeasonDefaultDirectory + "/poster.jpg";

        // 默认Work Episode文件夹
        public const string EpisodeDefaultDirectory = SeasonDefaultDirectory + "/E00 零集";
        // 默认Episode Fanart
        public const string EpisodeDefaultFanart = EpisodeDefaultDirectory + "/fanart.jpg";

        // 默认Work Movie文件夹
        public const string MovieDefaultDirectory = WorkDefaultDirectory + "/M00";
        // 默认Movie Poster
        public const string MovieDefaultPoster = MovieDefaultDirectory + "/poster.jpg";
        #endregion


        #region 本地数据映射成的静态文件相对路径
        // 存放图片的本地数据文件
        public const string DataImagesDirectory = "/SwellowData/Images";

        // Library的依据Id存放的fanart
        public const string DataImagesLibraryDirectory = DataImagesDirectory + "/Library";
        // Cast的依据Name存放的fanart
        public const string DataImagesCastDirectory = DataImagesDirectory + "/Cast";

        // TestVideos
        public const string TestVideosDirectory = "/TestVideos";

        #endregion


    }
}

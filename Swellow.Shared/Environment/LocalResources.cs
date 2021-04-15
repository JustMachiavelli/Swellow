
namespace Swellow.Shared.Environment
{
    public class LocalResources
    {
        //public const char SeparatorChar = System.IO.Path.DirectorySeparatorChar;

        // 当前程序文件夹所在目录【绝对路径】
        //public const string PathRoot = new System.IO.DirectoryInfo("../../").FullName.Replace("\\", "/");
        public const string Root = "D:/MyGit/MyProjects";


        #region 本地数据文件夹
        // 本地文件目录【绝对路径】
        public const string DataDirectory = Root + "/SwellowData";

        // 本地文件目录中的图片【绝对路径】
        public const string DataImagesDirectory = DataDirectory + "/Images";
        #endregion


        // 测试用电影【绝对路径】
        public const string TestMoviesDirectory = Root + "/TestVideos";
    }
}

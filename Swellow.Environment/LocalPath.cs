
namespace Swellow.Environment
{
    public class LocalPath
    {
        //public static char SeparatorChar = System.IO.Path.DirectorySeparatorChar;

        // 当前程序文件夹所在目录【绝对路径】
        //public static string PathRoot = new System.IO.DirectoryInfo("../../").FullName.Replace("\\", "/");
        public static string PathRoot = "D:/MyGit/MyProjects";

        // 缓存文件【绝对路径】
        public static string PathSwellowData = PathRoot + "/swellowdata";

        // 测试用电影【绝对路径】
        public static string PathTestMovies = PathRoot + "/testmovies";

    }
}

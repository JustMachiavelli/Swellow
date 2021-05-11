using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Swellow.LocalHost
{
    public class FileExplorer
    {
        // 0 获取主机名
        public static string GetHostName()
        {
            return Environment.MachineName;
        }

        // 1 获取所有磁盘 IEnumerable<string> driveInfos
        public static IEnumerable<string> GetDrives()
        {
            return Environment.GetLogicalDrives();
        }

        // 2 获取 目标目录path 下的所有子文件名
        // 两种情况: (1)path = ""，返回GetDrives()
        //           (2)path = "C:\"，返回正常
        public static IEnumerable<string> GetSubFolders(string path)
        {
            // (1)该路径为空, 用户在获取“我的电脑”
            if (path == "")
            {
                return GetDrives();
            }

            // (2)正常路径
            DirectoryInfo[] subDirectoryInfos;
            try
            {
                subDirectoryInfos = new DirectoryInfo(path).GetDirectories();
            }
            catch (Exception ex)
            {
                subDirectoryInfos = Array.Empty<DirectoryInfo>();
                if (ex is UnauthorizedAccessException || ex is SecurityException)
                {
                    Console.WriteLine("{0} = {1}", path, ex.Message);
                }
                else
                {
                    Console.WriteLine("{0}", ex.Message, path);
                }
            }

            List<DirectoryInfo> commonDirectorys = new();
            foreach (var dirInfo in subDirectoryInfos)
            {
                if ((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden
                    || (dirInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                {
                    //Console.WriteLine("{0} = {1}", dirInfo.FullName, dirInfo.Attributes.ToString());
                    continue;
                }
                commonDirectorys.Add(dirInfo);
            }
            return commonDirectorys.Select(directoryInfo => directoryInfo.Name).ToList();
        }


        // 3 获取 当前目录path 的上级目录
        // 3种情况: (1)path = "", DirectoryDetail{ ParentPath = null, }
        //          (2)path = "C:\", DirectoryDetail{ ParentPath = "", }
        //          (3)path = "C:\myFolder", DirectoryDetail{ ParentPath = "C:\", }
        public static string? GetParentPathAsync(string path)
        {
            if (path == "")
            {
                return null;
            }
            else
            {
                DirectoryInfo? parentDiretory = Directory.GetParent(path);
                if (parentDiretory == null)
                {
                    return "";
                }
                else
                {
                    return parentDiretory.FullName;
                }
            }
        }

    }
}

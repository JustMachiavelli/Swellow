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
        public static Task<string> GetHostName()
        {
            return Task.Run(() =>
            {
                return Environment.MachineName;
            });
        }

        // 1 获取所有磁盘 string[] driveInfos
        public static IEnumerable<string> GetDrives()
        {
            IEnumerable<string> drives = Environment.GetLogicalDrives();
            return drives;
        }

        // 2 获取path路径的目录下的所有子文件名
        public static Task<List<string>> GetSubFolders(string path)
        {
            return Task.Run(() =>
            {
                DirectoryInfo[] subDirectoryInfos = null;
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    subDirectoryInfos = dirInfo.GetDirectories();
                }
                catch (Exception ex)
                {
                    if (ex is UnauthorizedAccessException || ex is SecurityException)
                    {
                        Console.WriteLine("{0} = {1}", path, ex.Message);
                    }
                    else
                    {
                        Console.WriteLine("{0}", ex.Message, path);
                    }
                }

                List<DirectoryInfo> filteredList = new List<DirectoryInfo>();
                if (subDirectoryInfos != null && subDirectoryInfos.Length > 0)
                {
                    foreach (var dirInfo in subDirectoryInfos)
                    {
                        if ((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden
                            || (dirInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                        {
                            //Console.WriteLine("{0} = {1}", dirInfo.FullName, dirInfo.Attributes.ToString());
                            continue;
                        }

                        filteredList.Add(dirInfo);
                    }
                }
                return filteredList.Select(directoryInfo => directoryInfo.Name).ToList();
            });
        }
        

        // 4 获取路径path的上级目录
        public static Task<string> GetParentPathAsync(string path)
        {
            return Task.Run(()=>
            {
                DirectoryInfo parent = Directory.GetParent(path);
                string ParentPath = (parent is null) ? "/" : parent.FullName;
                return ParentPath;
            });
        }
    }
}

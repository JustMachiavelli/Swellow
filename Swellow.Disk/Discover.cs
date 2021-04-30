using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Swellow.Disk
{
    public class Discover
    {

        // 1 获取主机名
        public static Task<string> GetHostName()
        {
            return Task.Run(() =>
            {
                return Environment.MachineName;
            });
        }

        // 2 获取所有磁盘 string[] driveInfos
        public static Task<IEnumerable<string>> GetDrivesAsync()
        {
            return Task.Run(() =>
            {
                IEnumerable<string> drives = Environment.GetLogicalDrives();
                return drives;
            });
        }

        // 3 获取某一路径下的 DirectoryInfo[]
        public static Task<IEnumerable<string>> GetDirectoryInfos(string path)
        {
            return Task.Run(() =>
            {
                DirectoryInfo[] result = null;

                try
                {
                    var dirInfo = new DirectoryInfo(path);

                    result = dirInfo.GetDirectories();
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
                if (result != null && result.Length > 0)
                {
                    foreach (var dirInfo in result)
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

                return null;
            });
        }
        

    }
}

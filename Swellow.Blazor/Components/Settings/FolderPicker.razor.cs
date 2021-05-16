using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Shared.Dto.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Swellow.Blazor.Components.Settings
{
    public partial class FolderPicker
    {
        [Inject] public HostService HostService { get; set; }

        // 当前所处文件夹路径
        public string ParentDirectory { get; set; } = null;
        public string CurrentDirectory { get; set; } = string.Empty;
        public List<string> SubFolders { get; set; } = new List<string>();


        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("初始化……");
            SubFolders = await HostService.GetSubFoldersAsync(CurrentDirectory);
        }

        private async Task UpdateParentAsync()
        {
            Console.WriteLine($"我要去上级目录: {ParentDirectory}");
            CurrentDirectory = ParentDirectory;
            ParentDirectory = await HostService.GetParentDirectoryAsync(CurrentDirectory);
            SubFolders = await HostService.GetSubFoldersAsync(CurrentDirectory);
        }

        private async Task UpdateSubAsync(string folder)
        {
            ParentDirectory = CurrentDirectory;
            CurrentDirectory = (CurrentDirectory != "/") ? Path.Combine(CurrentDirectory, folder) : folder;
            Console.WriteLine($"我要去下级目录: {CurrentDirectory}");
            SubFolders = await HostService.GetSubFoldersAsync(CurrentDirectory);
        }

        protected override void OnAfterRender(bool firstRender = false)
        {
            Console.WriteLine("FolderPicker Render完毕！");
            Console.WriteLine($"上级目录：{ParentDirectory}");
            Console.WriteLine($"当前路径：{CurrentDirectory}");
            Console.WriteLine($"子文件夹们：{string.Join("、",SubFolders)}");
        }
    }
}

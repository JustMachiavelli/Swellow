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

        private DirectoryDetail Directory { get; set; } = new DirectoryDetail();

        //private bool isRoot = true;

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("初始化……");
            Directory = new()
            {
                Path = "/",
                ParentPath = null,
                SubFolders = await HostService.GetDrivesAsync()
            };
        }

        private async Task UpdateParentAsync()
        {
            Console.WriteLine($"我要去上级目录: {Directory.ParentPath}");
            Directory = await HostService.GetDirectoryDetailAsync(Directory.ParentPath);
            Console.WriteLine($"上级目录的路径：{Directory.Path}");
            //StateHasChanged();
        }

        private async Task UpdateSubAsync(string folder)
        {
            string subPath = (Directory.Path != "/") ? Path.Combine(Directory.Path, folder) : folder;
            Console.WriteLine($"我要去下级目录: {subPath}");
            Directory = await HostService.GetDirectoryDetailAsync(subPath);
            Console.WriteLine($"下级目录的路径：{Directory.Path}");
            //StateHasChanged();
        }

        protected override void OnAfterRender(bool firstRender = false)
        {
            Console.WriteLine("FolderPicker Render完毕！");
            Console.WriteLine($"当前路径：{Directory.Path}");
            Console.WriteLine($"上级目录：{Directory.ParentPath}");
            Console.WriteLine($"子文件夹们：{string.Join("、",Directory.SubFolders.ToList())}");
        }
    }
}

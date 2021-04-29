using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using Swellow.Shared.Dto.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Blazor.Components.Settings
{
    public partial class FolderPicker
    {
        [Inject] public DiskService DiskService { get; set; }

        [Parameter] public DirectoryDetail Directory { get; set; }

        protected override void OnInitialized()
        {
            Directory = DiskService.GetDirectoryDetailAsync(string.Empty);
        }

        private void Update(string path)
        {
            Directory = DiskService.GetDirectoryDetailAsync(path);
        }

    }
}

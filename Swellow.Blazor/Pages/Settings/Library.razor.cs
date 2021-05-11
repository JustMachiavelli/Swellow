using System.Collections.Generic;
using System.Threading.Tasks;
using Swellow.Shared.Enum;
using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Forms;
using Swellow.Shared.Dto.Settings;
using Swellow.Shared.Dto.View;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace Swellow.Blazor.Pages.Settings
{
    public partial class Library
    {

        [Inject] public LibraryService LibraryService { get; set; }

        #region 自身
        //1 是否显示“添加新媒体库”的模态框
        public bool IsPickingDirectory { get; set; } = false;

        //2 新媒体库的form模型
        private EditContext EditContext;
        public LibraryCreateEdit NewLibrary { get; set; }

        //3 新媒体库的类型选项
        private readonly IEnumerable<SelectedItem> Items = new SelectedItem[]
        {
            //new SelectedItem ("", "请选择..."),
            new SelectedItem ("Movie", "电影"),
            new SelectedItem ("Tv", "电视剧"),
        };

        //3 新媒体库的在线上传图片
        public IBrowserFile Picture { get; set; }
        #endregion

        // 4 用户刚刚添加的文件夹
        private string PickedDirectory { get; set; } = "待选择...";

        // 5 用户添加的文件夹集
        private List<string> Directorys { get; set; }

        #region httpClient
        //4 所有Library预览
        private IEnumerable<LibraryPreview> LibraryPreviews { get; set; } = new List<LibraryPreview>();
        #endregion

        #region 生命周期
        //【OnInitialized】
        protected override async Task OnInitializedAsync()
        {
            EditContext = new(NewLibrary);
            LibraryPreviews = await LibraryService.GetAllLibraryPreviewsAsync();
        }

        protected override void OnAfterRender(bool firstRender = false)
        {
            System.Console.WriteLine("Settings Library Render完毕！");
        }
        #endregion

        #region 表单数据验证
        private Task HandleSubmit()
        {
            if (PickedDirectory != "待选择...")
            {
                bool isValid = EditContext.Validate();
                if (isValid)
                {
                    return HandleValidSubmit();
                }
            }
            return HandleInvalidSubmit();
        }

        private Task HandleValidSubmit()
        {
            System.Console.WriteLine("表单合法");
            IsPickingDirectory = false;
            return Task.CompletedTask;
        }

        private static Task HandleInvalidSubmit()
        {
            System.Console.WriteLine("表单不合法");
            return Task.CompletedTask;
        }

        private void ToShowModalDirectoryPicker()
        {
            IsPickingDirectory = true;
            System.Console.WriteLine("我要显示表单");
        }

        private void ToCloseModalDirectoryrPicker()
        {
            IsPickingDirectory = false;
            System.Console.WriteLine("我要关闭表单");
        }
        #endregion

        

    }
}

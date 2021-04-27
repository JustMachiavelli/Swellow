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
        public bool isShowModal { get; set; } = false;

        //2 新媒体库的form模型
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

        #region httpClient
        //4 所有Library预览
        private IEnumerable<LibraryPreview> LibraryPreviews { get; set; } = new List<LibraryPreview>();
        #endregion

        #region 生命周期
        //【OnInitialized】
        protected override async Task OnInitializedAsync()
        {
            LibraryPreviews = await LibraryService.GetAllLibraryPreviewsAsync();
            NewLibrary = new LibraryCreateEdit
            {
                Name = "",
            };
        }
        #endregion

        #region 表单数据验证
        private Task OnValidSubmit(EditContext context)
        {
            System.Console.WriteLine("表单合法");
            isShowModal = false;
            return Task.CompletedTask;
        }

        private Task OnInvalidSubmit(EditContext context)
        {
            System.Console.WriteLine("表单不合法");
            return Task.CompletedTask;
        }

        private void ToShowModal()
        {
            isShowModal = true;
            System.Console.WriteLine("我要显示表单");
        }

        private void ToCloseModal()
        {
            isShowModal = false;
            System.Console.WriteLine("我要关闭表单");
        }
        #endregion

        private async Task OnUploadFolder(UploadFile file)
        {
            // 上传文件夹时会多次回调此方法
            await SaveToFile(file);
        }

        private async Task<bool> SaveToFile(UploadFile file)
        {
            // Server Side 使用
            // Web Assembly 模式下必须使用 webapi 方式去保存文件到服务器或者数据库中
            // 生成写入文件名称
            var ret = false;
            if (!string.IsNullOrEmpty(SiteOptions.Value.WebRootPath))
            {
                var uploaderFolder = Path.Combine(SiteOptions.Value.WebRootPath, $"images{Path.DirectorySeparatorChar}uploader");
                file.FileName = $"{Path.GetFileNameWithoutExtension(file.OriginFileName)}-{DateTimeOffset.Now:yyyyMMddHHmmss}{Path.GetExtension(file.OriginFileName)}";
                var fileName = Path.Combine(uploaderFolder, file.FileName);

                ReadToken ??= new CancellationTokenSource();
                ret = await file.SaveToFile(fileName, MaxFileLength, ReadToken.Token);

                if (ret)
                {
                    // 保存成功
                    file.PrevUrl = $"images/uploader/{file.FileName}";
                }
                else
                {
                    var errorMessage = $"保存文件失败 {file.OriginFileName}";
                    file.Code = 1;
                    file.Error = errorMessage;
                    await ToastService.Error("上传文件", errorMessage);
                }
            }
            else
            {
                file.Code = 1;
                file.Error = "Wasm 模式未实现保存代码";
                await ToastService.Information("保存文件", "当前模式为 WebAssembly 模式，请调用 Webapi 模式保存文件到服务器端或数据库中");
            }
            return ret;
        }

    }
}

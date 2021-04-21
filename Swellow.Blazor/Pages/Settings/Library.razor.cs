using System.Collections.Generic;
using System.Threading.Tasks;
using Swellow.Shared.Enum;
using Microsoft.AspNetCore.Components;
using Swellow.Blazor.Services;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Forms;
using Swellow.Shared.Dto.Settings;
using Swellow.Shared.Dto.View;

namespace Swellow.Blazor.Pages.Settings
{
    public partial class Library
    {

        [Inject] public LibraryService LibraryService { get; set; }


        //1 是否显示“添加新媒体库”的模态框【自身】
        public bool isShowModal { get; set; } = false;


        //2 新媒体库的form模型【自身】
        public LibraryCreateEdit NewLibrary { get; set; }


        //3 新媒体库的类型选项【自身】
        private readonly IEnumerable<SelectedItem> Items = new SelectedItem[]
        {
            //new SelectedItem ("", "请选择..."),
            new SelectedItem ("Movie", "电影"),
            new SelectedItem ("Tv", "电视剧"),
        };

        //3 新媒体库的在线上传图片【自身】
        public IBrowserFile Picture { get; set; }


        //4 所有Library预览【后传】
        private IEnumerable<LibraryPreview> LibraryPreviews { get; set; } = new List<LibraryPreview>();


        //【OnInitialized】
        protected override async Task OnInitializedAsync()
        {
            NewLibrary = new LibraryCreateEdit
            {
                Name = "",
            };
            LibraryPreviews = await LibraryService.GetAllLibraryPreviewsAsync();
            await base.OnInitializedAsync();
        }

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
    }
}

using Microsoft.AspNetCore.Mvc;
using Swellow.Data.SqlModel.View;
using Swellow.Data.Worker;
using Swellow.Web.ModelComponents;
using Swellow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ViewModelWorker _viewModelWorker;

        public SettingsController(ViewModelWorker viewModelWorker)
        {
            _viewModelWorker = viewModelWorker;
        }

        // 呈现控制台
        public IActionResult Dashboard()
        {
            return View();
        }

        // 呈现设置的展示所有媒体库
        public IActionResult LibraryPreviews()
        {
            List<LibraryPreview> libraryPreviews = new List<LibraryPreview>();
            foreach (Library library in _viewModelWorker.GetAllLibrarys())
            {
                LibraryPreview libraryPreview = new LibraryPreview
                {
                    Id = library.Id,
                    Name = library.Name,
                    PathPicture = library.PathPicture,
                };
                libraryPreviews.Add(libraryPreview);
            };
            LibrarySettingsViewModel settingsLibraryViewModel = new LibrarySettingsViewModel
            {
                LibraryPreviews = libraryPreviews,
            };
            return View(settingsLibraryViewModel);
        }

        // 呈现设置的编辑所有媒体库
        [HttpGet]
        public IActionResult LibraryEdit()
        {
            return View();
        }

        // 呈现设置的编辑所有媒体库
        [HttpPost]
        public IActionResult LibraryEdit(LibraryCreateViewModel model)
        {
            //_iLibrary.SaveNewLibrary(model);
            return RedirectToAction("LibraryPreviews");
        }
    }
}

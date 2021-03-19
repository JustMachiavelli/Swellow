using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Services;
using Swellow.Model.ViewModel.Components;
using Swellow.Model.ViewModel.Media;
using Swellow.Shared.SqlModel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Controllers
{

    [ApiController]
    [Route("api/librarys")]
    public class LibraryController : ControllerBase
    {
        private readonly DbManager _dbManager;

        public LibraryController(DbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public Task<IActionResult> GetLibrarys()
        {
            List<LibraryPreview> libraryPreviews = new();
            foreach (Library library in _dbManager.GetAllLibrarys())
            {
                LibraryPreview libraryPreview = new()
                {
                    Id = library.Id,
                    Name = library.Name,
                    PathImage = library.PathImage,
                };
                libraryPreviews.Add(libraryPreview);
            };

            HomeViewModel homeViewModel = new()
            {
                LibraryPreviews = libraryPreviews,
            };
            return new JsonResult(homeViewModel);
        }

    }
}

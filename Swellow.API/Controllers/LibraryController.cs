using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Sql;
using Swellow.Shared.ViewModel.Dto;
using Swellow.Shared.ViewModel.Media;
using Swellow.Shared.SqlModel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Controllers
{

    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly DbManager _dbManager;
        private readonly IMapper _mapper;


        public LibraryController(DbManager dbManager, IMapper mapper)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("api/librarys")]
        public async Task<IEnumerable<LibraryPreview>> GetAllLibrarys()
        {
            IEnumerable<Library> librarys = await _dbManager.GetAllLibrarysAsync();
            IEnumerable<LibraryPreview> libraryPreviews = _mapper.Map<IEnumerable<LibraryPreview>>(librarys);
            return libraryPreviews;
        }



        [HttpGet("api/library/{id}/name")]
        public async Task<string> GetLibraryNameAsync(int id)
        {
            return await _dbManager.GetLibraryNameByIdAsync(id);
        }

    }
}

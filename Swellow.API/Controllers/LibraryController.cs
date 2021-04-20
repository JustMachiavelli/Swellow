using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Sql;
using Swellow.Shared.Dto.View;
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
        private readonly LibraryRepository _libraryRepository;
        private readonly IMapper _mapper;


        public LibraryController(LibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository ?? throw new ArgumentNullException(nameof(LibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // 1 获取所有libraryPreview，主要用于Home主页
        [HttpGet("api/library/previews")]
        public async Task<IEnumerable<LibraryPreview>> GetAllLibraryPreviewsAsync()
        {
            IEnumerable<LibraryPreview> libraryPreviews = await _libraryRepository.GetAllLibraryPreviewsAsync();
            return libraryPreviews;
        }


        // 2 依据Id获取某个Library的Name
        [HttpGet("api/library/{id}/name")]
        public async Task<string> GetLibraryNameByIdAsync(int id)
        {
            return await _libraryRepository.GetLibraryNameByIdAsync(id);
        }

    }
}

//IEnumerable<LibraryPreview> libraryPreviews = _mapper.Map<IEnumerable<LibraryPreview>>(librarys);
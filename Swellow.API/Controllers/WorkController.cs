using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Sql;
using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Controllers
{
    public class WorkController : ControllerBase
    {
        private readonly DbManager _dbManager;
        private readonly IMapper _mapper;

        public WorkController(DbManager dbManager, IMapper mapper)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("api/library/{libraryId}/works")]
        public Task<IEnumerable<WorkPreview>> GetWorkPreviewsByLibraryIdAsync(int libraryId)
        {
            return _dbManager.GetWorkPreviewsByLibraryIdAsync(libraryId);
        }


        [HttpGet("api/library/{libraryId}/work/{workId}")]
        public async Task<Work> GetWorkByIdAsync(int workId)
        {
            var  work = await _dbManager.GetWorkByIdAsync(workId);
            foreach (var season in work.Seasons)
            {
                season.Work = null;
            }
            foreach (var movie in work.Movies)
            {
                movie.Work = null;
            }
            return work;
        }

    }
}

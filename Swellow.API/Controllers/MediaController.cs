using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Sql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swellow.Shared.Dto.Metadata.Media;
using Swellow.Shared.Dto.Metadata.Media.Television;
using Swellow.Shared.Dto.Metadata.Media.Film;

namespace Swellow.API.Controllers
{
    public class MediaController : ControllerBase
    {
        private readonly MediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public MediaController(MediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository ?? throw new ArgumentNullException(nameof(mediaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // 1 查找一个Library下的Work
        [HttpGet("api/library/{libraryId}/workPreviews")]
        public async Task<IEnumerable<WorkPreview>> GetWorkPreviewsByLibraryIdAsync(int libraryId)
        {
            IEnumerable<WorkPreview> workPreviews = await _mediaRepository.GetWorkPreviewsByLibraryIdAsync(libraryId);
            return workPreviews;
        }


        // 2 依据Work Id获取某个WorkDetail
        [HttpGet("api/work/{workId}/workDetail")]
        public async Task<WorkDetail> GetWorkDetailByIdAsync(int workId)
        {
            WorkDetail workDetail = await _mediaRepository.GetWorkDetailByIdAsync(workId);
            return workDetail;
        }


        // 3 依据Work Id获取Seasons
        [HttpGet("api/work/{workId}/seasonPreviews")]
        public async Task<IEnumerable<SeasonPreview>> GetSeasonPreviewAsync(int workId)
        {
            List<SeasonPreview> seasonPreviews = await _mediaRepository.GetSeasonPreviewsAsync(workId);
            return seasonPreviews;
        }


        // 4 依据Work Id获取Movies
        [HttpGet("api/work/{workId}/moviePreviews")]
        public async Task<IEnumerable<MoviePreview>> GetMoviePreviewsAsync(int workId)
        {
            List<MoviePreview> moviePreviews = await _mediaRepository.GetMoviePreviewsAsync(workId);
            return moviePreviews;
        }




    }         
}

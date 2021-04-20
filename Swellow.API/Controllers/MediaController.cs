using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Sql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swellow.Shared.Dto.Metadata.Media;
using Swellow.Shared.Dto.Metadata.Media.Television;
using Swellow.Shared.Dto.Metadata.Media.Film;
using Swellow.Shared.SqlModel.MetaData.Property;
using Swellow.Shared.Dto.Metadata.Property;
using Swellow.Shared.Dto.Metadata.Person;

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


        // 1 依据Work Id获取某个WorkDetail
        [HttpGet("api/work/{workId}/workDetail")]
        public async Task<WorkDetail> GetWorkDetailByIdAsync(int workId)
        {
            WorkDetail workDetail = await _mediaRepository.GetWorkDetailByIdAsync(workId);
            return workDetail;
        }


        // 2 依据Work Id获取Seasons
        [HttpGet("api/work/{workId}/seasonPreviews")]
        public async Task<IEnumerable<SeasonPreview>> GetSeasonPreviewAsync(int workId)
        {
            IEnumerable<SeasonPreview> seasonPreviews = await _mediaRepository.GetSeasonPreviewsAsync(workId);
            return seasonPreviews;
        }


        // 3 依据Work Id获取Movies
        [HttpGet("api/work/{workId}/moviePreviews")]
        public async Task<IEnumerable<MoviePreview>> GetMoviePreviewsAsync(int workId)
        {
            IEnumerable<MoviePreview> moviePreviews = await _mediaRepository.GetMoviePreviewsAsync(workId);
            return moviePreviews;
        }


        //4 依据Work Id获取Genres
        [HttpGet("api/work/{workId}/genres")]
        public async Task<IEnumerable<GenrePreview>> GetGenresAsync(int workId)
        {
            IEnumerable<GenrePreview> genrePreviews = await _mediaRepository.GetGenrePreviewsAsync(workId);
            return genrePreviews;
        }


        //5 依据Work Id获取Genres
        [HttpGet("api/work/{workId}/casts")]
        public async Task<IEnumerable<CastPreview>> GetCastsAsync(int workId)
        {
            IEnumerable<CastPreview> castPreviews = await _mediaRepository.GetCastPreviewsAsync(workId);
            return castPreviews;
        }



    }         
}

using Microsoft.EntityFrameworkCore;
using Swellow.API.Sql.Init;
using Swellow.Shared.Dto.Metadata.Media;
using Swellow.Shared.Dto.Metadata.Media.Film;
using Swellow.Shared.Dto.Metadata.Media.Television;
using Swellow.Shared.SqlModel.Metadata.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Sql
{
    public class MediaRepository
    {
        private readonly SwellowDbContext _context;

        public MediaRepository(SwellowDbContext swellowDbContext)
        {
            _context = swellowDbContext;
        }


        // 1 得到Works，通过LibraryId
        public async Task<IEnumerable<WorkPreview>> GetWorkPreviewsByLibraryIdAsync(int id)
        {
            var workPreviews = await _context.Works.Where(Work => Work.LibraryId == id)
                                      .Select(Work => new WorkPreview
                                      { 
                                          Id = Work.Id, 
                                          Name = Work.Name, 
                                          Year = Work.Year, 
                                          Type = Work.Type,
                                          Poster = Work.Poster,
                                      })
                                      .ToListAsync();

            return workPreviews;
        }


        // 2 得到一个Work详情，通过WorkId
        public async Task<WorkDetail> GetWorkDetailByIdAsync(int id)
        {
            WorkDetail workDetail = await _context.Works.Where(Work => Work.Id == id)
                                            .Select(work => new WorkDetail
                                            {
                                                Id = work.Id,
                                                Name = work.Name,
                                                Outline = work.Outline,
                                                Region = work.Region,
                                                DoubanId = work.DoubanId,
                                                TmdbId = work.TmdbId,
                                                ImdbId = work.ImdbId,
                                                Runtime = work.Runtime,
                                                Year =  work.Year,
                                                EndYear = work.EndYear,
                                                Date = work.Date,
                                                Score = work.Score,
                                                Directory = work.Directory,
                                                Poster = work.Poster,
                                                SeriesId = work.SeriesId,
                                            })
                                        .SingleOrDefaultAsync();
            return workDetail;
        }


        // 3 依据Work Id获取SeasonPreviews
        internal async Task<List<SeasonPreview>> GetSeasonPreviewsAsync(int workId)
        {
            List<SeasonPreview> seasonPreviews = await _context.Seasons.Where(season => season.WorkId == workId)
                                                                .Select(season => new SeasonPreview
                                                                {
                                                                    Id = season.Id,
                                                                    No = season.No,
                                                                    Year = season.Year,
                                                                    EndYear = season.EndYear,
                                                                    Poster = season.Poster,
                                                                })
                                                                .ToListAsync();
            return seasonPreviews;
        }


        // 4 依据Work Id获取MoviePreviews
        internal async Task<List<MoviePreview>> GetMoviePreviewsAsync(int workId)
        {
            List<MoviePreview> moviePreviews = await _context.Movies.Where(movie => movie.WorkId == workId)
                                                                    .Select(movie => new MoviePreview
                                                                    {
                                                                        Id = movie.Id,
                                                                        Name = movie.Name,
                                                                        Year = movie.Year,
                                                                        Date = movie.Date,
                                                                        Score = movie.Score,
                                                                        Poster = movie.Poster,
                                                                    })
                                                                    .ToListAsync();
            return moviePreviews;
        }


    }
}
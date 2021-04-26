using Microsoft.EntityFrameworkCore;
using Swellow.API.Sql.Init;
using Swellow.Shared.Dto.Metadata.Media;
using Swellow.Shared.Dto.Metadata.Media.Film;
using Swellow.Shared.Dto.Metadata.Media.Television;
using Swellow.Shared.Dto.Metadata.Person;
using Swellow.Shared.Dto.Metadata.Property;
using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.Metadata.Property;
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

        // 1 得到一个Work详情，通过WorkId
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
                                                Type = work.Type,
                                                Year =  work.Year,
                                                EndYear = work.EndYear,
                                                Date = work.Date,
                                                Score = ((float)work.Score / 10).ToString("0.0"),
                                                Directory = work.Directory,
                                                Poster = work.Poster,
                                                Fanart = work.Fanart,
                                                SeriesId = work.SeriesId,
                                            })
                                        .SingleOrDefaultAsync();
            return workDetail;
        }

        // 2 依据Work Id获取SeasonPreviews
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

        // 3 依据Work Id获取MoviePreviews
        internal async Task<List<MoviePreview>> GetMoviePreviewsAsync(int workId)
        {
            List<MoviePreview> moviePreviews = await _context.Movies.Where(movie => movie.WorkId == workId)
                                                                    .Select(movie => new MoviePreview
                                                                    {
                                                                        Id = movie.Id,
                                                                        No = movie.No,
                                                                        Name = movie.Name,
                                                                        Year = movie.Year,
                                                                        Date = movie.Date,
                                                                        Score = movie.Score,
                                                                        Poster = movie.Poster,
                                                                    })
                                                                    .ToListAsync();
            return moviePreviews;
        }

        // 4 依据Work Id获取Genres
        internal async Task<List<GenrePreview>> GetGenrePreviewsAsync(int workId)
        {
            List<GenrePreview> genrePreviews = await _context.WorkGenres.Where(workGenre => workGenre.WorkId == workId)
                                                            .Select(workGenre => new GenrePreview
                                                            {
                                                                Id = workGenre.Genre.Id,
                                                                Name = workGenre.Genre.Name,
                                                            })
                                                            .ToListAsync();
            return genrePreviews;
        }

        // 5 依据Work Id获取Casts
        internal async Task<IEnumerable<CastPreview>> GetCastPreviewsAsync(int workId)
        {
            List<CastPreview> castPreviews = await _context.WorkCasts.Where(workCast => workCast.WorkId == workId)
                                                            .Select(workCast => new CastPreview
                                                            {
                                                                Id = workCast.Cast.Id,
                                                                Name = workCast.Cast.Name,
                                                                Poster = workCast.Cast.Poster,
                                                                Type = workCast.Type,
                                                            })
                                                            .ToListAsync();
            return castPreviews;
        }

        // 6 依据Work Id获取Work Name
        internal async Task<string> GetWorkNameAsync(int workId)
        {
            string workName = await _context.Works.Where(work => work.Id == workId)
                                                  .Select(work => work.Name)
                                                  .SingleOrDefaultAsync();
            return workName;
        }

        // 7 依据Work Id Season Id获取IEnumerable<EpisodePreview>
        internal async Task<SeasonDetail> GetSeasonDetailAsync(int seasonId)
        {
            SeasonDetail seasonDetail = await _context.Seasons.Where(season => season.Id == seasonId)
                                                    .Select(season => new SeasonDetail
                                                    {
                                                        Id = season.Id,
                                                        No = season.No,
                                                        Outline = season.Outline,
                                                        Year = season.Year,
                                                        EndYear = season.EndYear,
                                                        Poster = season.Poster,
                                                    })
                                                  .SingleOrDefaultAsync();
            return seasonDetail;

        }

        // 8 依据Work Id Season Id获取Work Name
        internal async Task<IEnumerable<EpisodePreview>> GetEpisodePreviewsAsync(int seasonId)
        {
            List<EpisodePreview> episodePreviews = await _context.Episodes.Where(episode => episode.SeasonId == seasonId)
                                                            .Select(episode => new EpisodePreview
                                                            {
                                                                Id = episode.Id,
                                                                No= episode.No,
                                                                Title = episode.Title,
                                                                Plot = episode.Plot,
                                                                Date = episode.Date,
                                                                Fanart = episode.Fanart,
                                                            })
                                                            .ToListAsync();
            return episodePreviews;
        }

        internal async Task<MovieDetail> GetMovieDetailAsync(int movieId)
        {
            MovieDetail movieDetail = await _context.Movies.Where(movie => movie.Id == movieId)
                                                    .Select(movie => new MovieDetail
                                                    {
                                                        Id = movie.Id,
                                                        Name = movie.Name,
                                                        Outline = movie.Outline,
                                                        DoubanId = movie.DoubanId,
                                                        TmdbId = movie.TmdbId,
                                                        ImdbId = movie.ImdbId,

                                                        Runtime = movie.Runtime,
                                                        Year = movie.Year,
                                                        Date = movie.Date,
                                                        Score = movie.Score,
                                                        Poster = movie.Poster,
                                                    })
                                                  .SingleOrDefaultAsync();
            return movieDetail;
        }



    }
}
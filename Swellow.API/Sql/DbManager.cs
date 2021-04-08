using Microsoft.EntityFrameworkCore;
using Swellow.API.Sql.Init;
using Swellow.Shared.SqlModel.People;
using Swellow.Shared.SqlModel.View;
using Swellow.Shared.SqlModel.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Sql
{
    public class DbManager : IDbManager
    {
        private readonly SwellowDbContext _context;

        public DbManager(SwellowDbContext swellowDbContext)
        {
            _context = swellowDbContext;
        }


        // 【Library】1得到所有Library
        public async Task<IEnumerable<Library>> GetAllLibrarysAsync()
        {
            return await _context.Librarys.ToListAsync();
        }

        // 【Library】2得到一个Library的Name
        public async Task<string> GetLibraryNameByIdAsync(int id)
        {
            return await _context.Librarys.Where(Library => Library.Id == id)
                                        .Select(Library => Library.Name)
                                        .FirstOrDefaultAsync();
        }


        // 【Video】1得到Videos，通过LibraryId
        public async Task<IEnumerable<Work>> GetVideosByLibraryIdAsync(int id)
        {
            return await _context.Videos.Where(Video => Video.LibraryId == id)
                                        .ToListAsync();
        }

        // 【Video】2得到一个Video，通过VideoId
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie movie = await _context.Movies.Where(Movie => Movie.Id == id)
                                    .Include(Movie => Movie.VideoActors)
                                        .ThenInclude(VideoActor => VideoActor.Cast)
                                    .Include(Movie => Movie.VideoDirectors)
                                        .ThenInclude(VideoDirector => VideoDirector.Cast)
                                    .Include(Movie => Movie.VideoGenres)
                                        .ThenInclude(VideoGenre => VideoGenre.Genre)
                                    .FirstOrDefaultAsync();
            return movie;
        }

        // 【Video】2得到一个Video，通过VideoId
        public async Task<Tv> GetTvByIdAsync(int id)
        {
            return await _context.Tvs.Where(Tv => Tv.Id == id)
                                    .FirstOrDefaultAsync();
        }

        public async Task<Cast> GetCastByIdAsync(int id)
        {
            Cast cast = await _context.Casts.Where(Cast => Cast.Id == id)
                                    .Include(Cast => Cast.VideoActors)
                                        .ThenInclude(VideoActor => VideoActor.Video)
                                    .Include(Cast => Cast.VideoDirectors)
                                        .ThenInclude(VideoDirector => VideoDirector.Video)
                                    .FirstOrDefaultAsync();
            return cast;
        }
    }
}

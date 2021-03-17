using Microsoft.EntityFrameworkCore;
using Swellow.Shared.SqlModel.People;
using Swellow.Shared.SqlModel.View;
using Swellow.Shared.SqlModel.Works;
using Swellow.SqlInit.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Services
{
    public class DbManager
    {
        private readonly SwellowDbContext _context;

        public DbManager(SwellowDbContext swellowDbContext)
        {
            _context = swellowDbContext;
        }


        // 【Library】1得到所有Library
        public IEnumerable<Library> GetAllLibrarys()
        {
            return _context.Librarys.ToArray();
        }

        // 【Library】2得到一个Library的Name
        public string GetLibraryNameById(int id)
        {
            return _context.Librarys.Where(Library => Library.Id == id)
                                    .Select(Library => Library.Name)
                                    .FirstOrDefault();
        }


        // 【Video】1得到Videos，通过LibraryId
        public IEnumerable<Video> GetVideosByLibraryId(int id)
        {
            return _context.Videos.Where(Video => Video.IdLibrary == id).ToArray();
        }

        // 【Video】2得到一个Video，通过VideoId
        public Movie GetMovieById(int id)
        {
            Movie movie = _context.Movies.Where(Movie => Movie.Id == id)
                                    .Include(Movie => Movie.VideoActors)
                                        .ThenInclude(VideoActor => VideoActor.Cast)
                                    .Include(Movie => Movie.VideoDirectors)
                                        .ThenInclude(VideoDirector => VideoDirector.Cast)
                                    .Include(Movie => Movie.VideoGenres)
                                        .ThenInclude(VideoGenre => VideoGenre.Genre)
                                    .FirstOrDefault();
            return movie;
        }

        // 【Video】2得到一个Video，通过VideoId
        public Tv GetTvById(int id)
        {
            return _context.Tvs.FirstOrDefault(Tv => Tv.Id == id);
        }

        public Cast GetCastById(int id)
        {
            Cast cast = _context.Casts.Where(Cast => Cast.Id == id)
                                    .Include(Cast => Cast.VideoActors)
                                        .ThenInclude(VideoActor => VideoActor.Video)
                                    .Include(Cast => Cast.VideoDirectors)
                                        .ThenInclude(VideoDirector => VideoDirector.Video)
                                    .FirstOrDefault();
            return cast;
        }
    }
}

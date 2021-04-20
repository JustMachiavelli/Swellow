using Microsoft.EntityFrameworkCore;
using Swellow.API.Sql.Init;
using Swellow.Shared.SqlModel.MetaData.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Sql
{
    public class PersonRepository
    {
        private readonly SwellowDbContext _context;

        public PersonRepository(SwellowDbContext swellowDbContext)
        {
            _context = swellowDbContext;
        }


        // 1得到一个Cast，通过CastId
        public async Task<Cast> GetCastByIdAsync(int id)
        {
            Cast cast = await _context.Casts.Where(Cast => Cast.Id == id)
                                    .Include(Cast => Cast.WorkCasts)
                                        .ThenInclude(WorkCast => WorkCast.Work)
                                    .FirstOrDefaultAsync();
            return cast;
        }
    }
}

//Cast cast = await _context.Casts.Where(Cast => Cast.Id == id)
//                        .Include(Cast => Cast.VideoActors)
//                            .ThenInclude(VideoActor => VideoActor.Video)
//                        .Include(Cast => Cast.VideoDirectors)
//                            .ThenInclude(VideoDirector => VideoDirector.Video)
//                        .FirstOrDefaultAsync();

using Microsoft.EntityFrameworkCore;
using Swellow.API.Sql.Init;
using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.MetaData.Person;
using Swellow.Shared.SqlModel.View;
using Swellow.Shared.ViewModel.Dto;
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


        // 【Library】1.1得到所有Library
        public async Task<IEnumerable<Library>> GetAllLibrarysAsync()
        {
            return await _context.Librarys.ToListAsync();
        }


        // 【Library】1.2得到一个Library的Name
        public async Task<string> GetLibraryNameByIdAsync(int id)
        {
            return await _context.Librarys.Where(Library => Library.Id == id)
                                        .Select(Library => Library.Name)
                                        .FirstOrDefaultAsync();
        }


        // 【Work】2.1得到Works，通过LibraryId
        public async Task<IEnumerable<WorkPreview>> GetWorkPreviewsByLibraryIdAsync(int id)
        {
            List<WorkPreview> workPreviews = new ();
            foreach (var work in await _context.Works.Select(Work => new { Work.Id, Work.Display, Work.Year, Work.Type }).ToListAsync())
            {
                WorkPreview workPreview = new()
                {
                    Id = work.Id,
                    Display = work.Display,
                    Year = work.Year,
                    Type = work.Type,
                };
                workPreviews.Add(workPreview);
            }
            return workPreviews;
        }


        // 【Work】2.2得到一个Work详情，通过WorkId
        public async Task<Work> GetWorkByIdAsync(int id, WorkType type)
        {
            return type switch
            {
                WorkType.Mix => await _context.Works.Where(Work => Work.Id == id)
                                                    .Include(Work => Work.Seasons)
                                                    .Include(Work => Work.Movies)
                                                    .FirstOrDefaultAsync(),
                WorkType.SingleMovie => await _context.Works.Where(Work => Work.Id == id)
                                                            .Include(Work => Work.Movies)
                                                            .FirstOrDefaultAsync(),
                WorkType.SingleTv => await _context.Works.Where(Work => Work.Id == id)
                                                    .Include(Work => Work.Seasons)
                                                    .FirstOrDefaultAsync(),
                _ => null,
            };
        }


        // 3.1【Cast】得到一个Cast，通过CastId
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

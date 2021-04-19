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
    public class DbManager
    {
        private readonly SwellowDbContext _context;

        public DbManager(SwellowDbContext swellowDbContext)
        {
            _context = swellowDbContext;
        }


        #region Library媒体库
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
        #endregion


        #region Work影视作品
        // 【Work】1得到Works，通过LibraryId
        public async Task<IEnumerable<WorkPreview>> GetWorkPreviewsByLibraryIdAsync(int id)
        {
            var workPreviews = await _context.Works.Where(Work => Work.LibraryId == id)
                                      .Select(Work => new WorkPreview{ Id=Work.Id, Name=Work.Name, Year=Work.Year, Type=Work.Type })
                                      .ToListAsync();

            return workPreviews;
        }


        // 【Work】2得到一个Work详情，通过WorkId
        public async Task<Work> GetWorkByIdAsync(int id)
        {
            Work work =  await _context.Works.Where(Work => Work.Id == id)
                                        .Include(Work => Work.Seasons)
                                        .Include(Work => Work.Movies)
                                        .FirstOrDefaultAsync();
            return work;
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        #endregion


        #region Cast演职人员
        // 【Cast】1得到一个Cast，通过CastId
        public async Task<Cast> GetCastByIdAsync(int id)
        {
            Cast cast = await _context.Casts.Where(Cast => Cast.Id == id)
                                    .Include(Cast => Cast.WorkCasts)
                                        .ThenInclude(WorkCast => WorkCast.Work)
                                    .FirstOrDefaultAsync();
            return cast;
        }
        #endregion


    }
}



//Cast cast = await _context.Casts.Where(Cast => Cast.Id == id)
//                        .Include(Cast => Cast.VideoActors)
//                            .ThenInclude(VideoActor => VideoActor.Video)
//                        .Include(Cast => Cast.VideoDirectors)
//                            .ThenInclude(VideoDirector => VideoDirector.Video)
//                        .FirstOrDefaultAsync();



//var works = await _context.Works.Where(Work => Work.LibraryId == id)
//                          .Select(Work => new WorkPreview { Id = Work.Id, Name = Work.Name, Year = Work.Year, Type = Work.Type })
//                          .ToListAsync();
using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.MetaData.Person;
using Swellow.Shared.SqlModel.View;
using Swellow.Shared.ViewModel.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swellow.API.Sql
{
    public interface IDbManager
    {
        // 1.1【Library】得到所有Library
        Task<IEnumerable<Library>> GetAllLibrarysAsync();


        // 1.2【Library】得到一个Library的Name
        Task<string> GetLibraryNameByIdAsync(int id);


        // 2.1【Work】得到Works，通过LibraryId
        Task<IEnumerable<WorkPreview>> GetWorkPreviewsByLibraryIdAsync(int id);


        // 2.2【Work】得到一个Work，通过WorkId
        Task<Work> GetWorkByIdAsync(int id, WorkType type);


        // 3.1【Cast】得到一个Cast，通过CastId
        Task<Cast> GetCastByIdAsync(int id);
    }
}

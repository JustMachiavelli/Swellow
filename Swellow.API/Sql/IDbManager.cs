using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.MetaData.Person;
using Swellow.Shared.SqlModel.View;
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
        Task<IEnumerable<Work>> GetWorksByLibraryIdAsync(int id);

        // 3.1【Movie】得到一个Work，通过WorkId
        Task<Work> GetWorkByIdAsync(int id);


        // 5.1【Cast】得到一个Cast，通过CastId
        Task<Cast> GetCastByIdAsync(int id);
    }
}

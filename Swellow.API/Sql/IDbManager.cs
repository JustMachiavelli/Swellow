using Swellow.Model.SqlModel.People;
using Swellow.Model.SqlModel.View;
using Swellow.Model.SqlModel.Works;
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


        // 2.1【Video】得到Videos，通过LibraryId
        Task<IEnumerable<Work>> GetVideosByLibraryIdAsync(int id);

        // 3.1【Movie】得到一个Video，通过VideoId
        Task<Movie> GetMovieByIdAsync(int id);

        // 4.1【Tv】得到一个Video，通过VideoId
        Task<Tv> GetTvByIdAsync(int id);


        // 5.1【Cast】得到一个Cast，通过CastId
        Task<Cast> GetCastByIdAsync(int id);
    }
}

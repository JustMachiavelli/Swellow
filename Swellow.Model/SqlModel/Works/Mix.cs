using Swellow.Model.SqlModel.View;
using Swellow.Model.SqlModel.Works.Film;
using Swellow.Model.SqlModel.Works.Television;
using System.Collections.Generic;

namespace Swellow.Model.SqlModel.Works
{
    public class Mix : Work
    {
        // 1【集合导航】所属library
        public IEnumerable<Season> Seasons { get; set; } = new List<Season>();


        // 2【集合导航】所属library
        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();


        // 3【引用导航】所属library
        public int LibraryId { get; set; }
        public Library Library { get; set; }

    }
}

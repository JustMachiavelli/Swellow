using Swellow.Data.SqlModel.People;
using Swellow.Data.SqlModel.Property;
using Swellow.Data.SqlModel.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Web.Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Cast> Actors { get; set; }

        public IEnumerable<Cast> Directors { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}

using Swellow.Data.SqlModel.People;
using Swellow.Web.ModelComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.Web.Models
{
    public class CastDetailViewModel
    {
        public Cast Cast { get; set; }

        public IEnumerable<VideoPreview> VideoActedPreviews { get; set; }

        public IEnumerable<VideoPreview> VideoDirectedPreviews { get; set; }
    }
}

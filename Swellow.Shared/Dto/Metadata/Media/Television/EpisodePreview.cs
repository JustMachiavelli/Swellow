using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.LocalData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.Dto.Metadata.Media.Television
{
    public class EpisodePreview
    {
        public int Id { get; set; }
        public int No { get; set; } = 0;
        //public string? Display { get; set; }
        public string? Title { get; set; }
        public string? Plot { get; set; }
        public System.DateTime Date { get; set; }
        //public string? Directory { get; set; }
        public string? Fanart { get; set; }
        //public IEnumerable<CD>? CDs { get; set; } = new List<CD>();
        public bool HasResourse { get; set; }
    }
}

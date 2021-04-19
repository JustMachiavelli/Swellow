using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Shared.ViewModel.Dto
{
    public class SeasonPreview
    {
        public int Id { get; set; }
        public int No { get; set; } = 1;
        //public string? Outline { get; set; }
        public int? Year { get; set; }
        public int? EndYear { get; set; }
        //public string? Directory { get; set; }
        public string? Poster { get; set; }
        //public IEnumerable<Episode>? Episodes { get; set; } = new List<Episode>();
        //public int? WorkId { get; set; }
        //public Work? Work { get; set; }
    }
}

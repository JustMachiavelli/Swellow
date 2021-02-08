using System.Collections.Generic;

namespace Swellow.Web.Models
{
    public class LibraryViewModel
    {
        public string LibraryName { get; set; }
        public IEnumerable<ModelComponents.VideoPreview> VideoPreviews { get; set; }
    }
}

using Swellow.Shared.Enum;
using Swellow.Shared.Environment;

namespace Swellow.Shared.ViewModel.Dto
{
    public class CastPreview
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Poster { get; set; }

        public CastType Type { get; set; } = CastType.Unknown;

    }
}

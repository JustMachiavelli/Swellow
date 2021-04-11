using Swellow.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swellow.Shared.ViewModel.Dto
{
    public class CastPreview
    {
        public int Id { get; set; }

        public string Name { get; set; } = "未知演员";

        public string? Poster { get; set; }

        public CastType Type { get; set; } = CastType.Unknown;

    }
}

using System.Collections.Generic;

namespace Swellow.Shared.Dto.Settings
{
    public class DirectoryDetail
    {
        public string? Name { get; set; }

        public string? Path { get; set; }

        public string? ParentPath { get; set; }

        public IEnumerable<SubDirectory>? SubDirectorys { get; set; }

    }
}
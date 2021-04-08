using AutoMapper;
using Swellow.Shared.ViewModel.Dto;
using Swellow.Shared.SqlModel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Mapper
{
    public class LibraryMapper:Profile
    {
        public LibraryMapper()
        {
            CreateMap<Library, LibraryPreview>();
        }
    }
}

using AutoMapper;
using Swellow.Model.ViewModel.Dto;
using Swellow.Model.SqlModel.View;
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

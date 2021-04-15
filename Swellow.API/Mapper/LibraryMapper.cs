using AutoMapper;
using Swellow.Shared.ViewModel.Dto;
using Swellow.Shared.SqlModel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swellow.Shared.SqlModel.Metadata.Media;

namespace Swellow.API.Mapper
{
    public class LibraryMapper:Profile
    {
        public LibraryMapper()
        {
            CreateMap<Library, LibraryPreview>();

            CreateMap<Work, WorkPreview>()
                .ForMember(
                    dest => dest.Fanart,
                    opt => opt.MapFrom(Work => DateTime.Now.Year - src.DateOfBirth.Year));
        }
    }
}

using AutoMapper;
using Swellow.Shared.SqlModel.View;
using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.Dto.View;
using Swellow.Shared.Dto.Metadata.Media;

namespace Swellow.API.Mapper
{
    public class LibraryMapper:Profile
    {
        public LibraryMapper()
        {
            CreateMap<Library, LibraryPreview>();

            CreateMap<Work, WorkPreview>();
                //.ForMember(
                //    dest => dest.Fanart,
                //    opt => opt.MapFrom(Work => DateTime.Now.Year - src.DateOfBirth.Year));
        }
    }
}

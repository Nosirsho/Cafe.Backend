using AutoMapper;
using Cafe.Application.Common.Mappings;
using Cafe.Application.PlaceCategories.Commands.CreatePlaceCategory;

namespace Cafe.WebApi.Models {
	public class CreatePlaceCategoryDto : IMapWith<CreatePlaceCategoryCommand>{
        public string Name { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<CreatePlaceCategoryDto, CreatePlaceCategoryCommand>()
                .ForMember(pcCommand => pcCommand.Name, opt => opt.MapFrom(pcDto => pcDto.Name));
        }
    }
}

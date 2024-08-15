using AutoMapper;
using Cafe.Application.Common.Mappings;
using Cafe.Application.PlaceCategories.Commands.UpdatePlaceCategory;
using System;

namespace Cafe.WebApi.Models {
	public class UpdatePlaceCategoryDto : IMapWith<UpdatePlaceCategoryCommand>{

		public Guid Id { get; set; }
		public string Name { get; set; }
		public void Mapping(Profile profile) {
			profile.CreateMap<UpdatePlaceCategoryDto, UpdatePlaceCategoryCommand>()
				.ForMember(pcCommand => pcCommand.Name, opt => opt.MapFrom(pcDto => pcDto.Name))
				.ForMember(pcCommand => pcCommand.Id, opt => opt.MapFrom(pcDto => pcDto.Id));
		}
	}
}

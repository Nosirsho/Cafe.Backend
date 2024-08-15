using AutoMapper;
using Cafe.Application.Common.Mappings;
using Cafe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryList {
	public class PlaceCategoryLookupDto : IMapWith<PlaceCategory> {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public void Mapping(Profile profile) {
			profile.CreateMap<PlaceCategory, PlaceCategoryLookupDto>()
				.ForMember(pcDto => pcDto.Id, opt => opt.MapFrom(pc => pc.Id))
				.ForMember(pcDto => pcDto.Name, opt => opt.MapFrom(pc => pc.Name));
		}
	}
}

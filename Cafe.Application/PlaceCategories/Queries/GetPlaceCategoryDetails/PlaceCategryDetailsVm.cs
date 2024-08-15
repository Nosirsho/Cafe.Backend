using AutoMapper;
using Cafe.Application.Common.Mappings;
using Cafe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryDetails {
	public class PlaceCategryDetailsVm : IMapWith<PlaceCategory>{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? EditDate { get; set; }

		public void Mapping(Profile profile) {
			profile.CreateMap<PlaceCategory, PlaceCategryDetailsVm>()
				.ForMember(pcVm => pcVm.Name, opt => opt.MapFrom(pc => pc.Name))
				.ForMember(pcVm => pcVm.Id, opt => opt.MapFrom(pc => pc.Id))
				.ForMember(pcVm => pcVm.CreationDate, opt => opt.MapFrom(pc => pc.CreationDate))
				.ForMember(pcVm => pcVm.EditDate, opt => opt.MapFrom(pc => pc.EditDate));
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.PlaceCategories.Queries.GetPlaceCategoryList {
	public class PlaceCategoryListVm {
		public IList<PlaceCategoryLookupDto> PlaceCategories { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain {
	public class PlaceCategory {
		public Guid UserId { get; set; }
		public Guid Id { get; set; }
		public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}

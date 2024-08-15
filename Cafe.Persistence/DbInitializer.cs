using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Persistence {
	public class DbInitializer {
		public static void Initialize(CafeDbContext context) { 
			context.Database.EnsureCreated();
		}
	}
}

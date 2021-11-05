using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.MicroservicesAPI._7461.Model
{
	public class Pharmacy
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string Street { get; set; }
		public object Medicine { get; internal set; }
	}
}

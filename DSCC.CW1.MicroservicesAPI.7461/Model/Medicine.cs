using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.MicroservicesAPI._7461.Model
{
	public class Medicine
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime ProductionDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public int Quantity { get; set; }
	}
}

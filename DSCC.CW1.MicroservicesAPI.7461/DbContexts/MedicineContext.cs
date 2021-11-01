using DSCC.CW1.MicroservicesAPI._7461.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.MicroservicesAPI._7461.DbContexts
{
	public class MedicineContext:DbContext
	{
		public MedicineContext(DbContextOptions<MedicineContext> options) : base(options)
		{

		}
		public DbSet<Medicine> Medicines { get; set; }
		public DbSet<Pharmacy> Pharmacies { get; set; }

	}
}

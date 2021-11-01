using DSCC.CW1.MicroservicesAPI._7461.DbContexts;
using DSCC.CW1.MicroservicesAPI._7461.Model;
using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.MicroservicesAPI._7461.Repository
{
	public class MedicineRepository : IMedicineRepository
	{
		private readonly MedicineContext _dbContext;

		public MedicineRepository(MedicineContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteMedicines(int medicineId)
		{
			var medicine = _dbContext.Medicines.Find(medicineId);
			_dbContext.Medicines.Remove(medicine);
			Save();
		}

		//add implementation

		public Medicine GetMedicineById(int id)
		{
			throw new NotImplementedException();
		}

		//add implementation

		public IEnumerable<Medicine> GetMedicines()
		{
			throw new NotImplementedException();
		}

		public void InsertMedicine(Medicine medicine)
		{
			_dbContext.Add(medicine);
			Save();
		}

		public void UpdateMedicine(Medicine medicine)
		{
			_dbContext.Entry(medicine).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			Save();
		}
		private void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}

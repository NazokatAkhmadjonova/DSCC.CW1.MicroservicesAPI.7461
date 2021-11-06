
using DSCC.CW1.MicroservicesAPI._7461.DbContexts;
using DSCC.CW1.MicroservicesAPI._7461.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

		public void DeleteMedicine(int medicineId)
		{
			var medicine = _dbContext.Medicines.Find(medicineId);
			_dbContext.Medicines.Remove(medicine);
			Save();
		}

		public Medicine GetMedicineById(int medicineId)
		{
			var med = _dbContext.Medicines.Find(medicineId);
			_dbContext.Entry(med).Reference(m => m.Pharmacy).Load();
			return med;
		}

		public IEnumerable<Medicine> GetMedicines()
		{
			return _dbContext.Medicines.Include(m => m.Pharmacy).ToList();
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

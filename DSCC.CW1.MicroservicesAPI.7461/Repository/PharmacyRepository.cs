
using DSCC.CW1.MicroservicesAPI._7461.DbContexts;
using DSCC.CW1.MicroservicesAPI._7461.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.MicroservicesAPI._7461.Repository
{
	public class PharmacyRepository : IPharmacyRepository
	{
		private readonly MedicineContext _dbContext;
		public PharmacyRepository(MedicineContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeletePharmacy(int pharmacyId)
		{
			var pharmacy = _dbContext.Pharmacies.Find(pharmacyId);
			_dbContext.Pharmacies.Remove(pharmacy);
			Save();
		}

		public IEnumerable<Pharmacy> GetPharmacies()
		{
			return _dbContext.Pharmacies.ToList();
			//return _dbContext.Pharmacies.Include(p => p.Medicine).ToList();
		}

		public Pharmacy GetPharmacyById(int pharmacyId)
		{
			var phar = _dbContext.Pharmacies.Find(pharmacyId);
			//_dbContext.Entry(phar).Reference(p => p.Medicine).Load();
			return phar;
		}

		public void AddPharmacy(Pharmacy pharmacy)
		{
			_dbContext.Add(pharmacy);
			Save();
		}

		public void UpdatePharmacy(Pharmacy pharmacy)
		{
			_dbContext.Entry(pharmacy).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			Save();
		}
		private void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}

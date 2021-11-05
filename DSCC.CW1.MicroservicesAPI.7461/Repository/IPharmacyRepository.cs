using DSCC.CW1.MicroservicesAPI._7461.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.MicroservicesAPI._7461.Repository
{
	public interface IPharmacyRepository
	{
		void InsertPharmacy(Pharmacy pharmacy);
		void UpdatePharmacy(Pharmacy pharmacy);
		void DeletePharmacy(int medicineId);
		Pharmacy GetPharmacyById(int id);
		IEnumerable<Pharmacy> GetPharmacies();
	}
}

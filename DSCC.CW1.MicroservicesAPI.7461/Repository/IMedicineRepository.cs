using DSCC.CW1.MicroservicesAPI._7461.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC.CW1.MicroservicesAPI._7461.Repository
{
	public interface IMedicineRepository
	{
		void InsertMedicine(Medicine medicine);
		void UpdateMedicine(Medicine medicine);
		void DeleteMedicines(int medicineId);
		Medicine GetMedicineById(int id);
		IEnumerable<Medicine> GetMedicines();
	}
}

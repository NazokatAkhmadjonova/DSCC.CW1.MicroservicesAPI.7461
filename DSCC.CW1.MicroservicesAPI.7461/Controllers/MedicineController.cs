using DSCC.CW1.MicroservicesAPI._7461.Model;
using DSCC.CW1.MicroservicesAPI._7461.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC.CW1.MicroservicesAPI._7461.Controllers
{
	[Produces("application/json")]
	[Route("api/Medicine")]
	//[ApiController]
	public class MedicineController : Controller
	{
		private readonly IMedicineRepository _medicineRepository;
		public MedicineController(IMedicineRepository medicineRepository)
		{
			_medicineRepository = medicineRepository;
		}

		// GET: api/<MedicineController>
		[HttpGet]
		public IActionResult Get()
		{
			var products = _medicineRepository.GetMedicines();
			return new OkObjectResult(products);
			//return new string[] { "value1",  "value2" };
		}

		// GET api/<MedicineController>/5
		[HttpGet("{id}", Name ="Get")]
		public IActionResult Get(int id)
		{
			var medicine = _medicineRepository.GetMedicines();
			return new OkObjectResult(medicine);
		}

		// POST api/<MedicineController>
		[HttpPost]
		public IActionResult Post([FromBody] Medicine medicine)
		{
			using (var scope= new TransactionScope())
			{
				_medicineRepository.InsertMedicine(medicine);
				scope.Complete();
				return CreatedAtAction(nameof(Get), new { id = medicine.Id }, medicine);
			}
				
		}

		// PUT api/<MedicineController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int Id,
						   [FromBody] Medicine medicine)
		{
			if(medicine != null)
			{
				using (var scope = new TransactionScope())
				{
					_medicineRepository.UpdateMedicine(medicine);
					scope.Complete();
					return new OkResult();
				}
			}
			return new NoContentResult();
		}

		// DELETE api/<MedicineController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_medicineRepository.DeleteMedicine(id);
			return new OkResult();
		}
	}
}

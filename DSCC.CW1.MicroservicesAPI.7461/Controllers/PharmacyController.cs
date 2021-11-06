using DSCC.CW1.MicroservicesAPI._7461.Model;
using DSCC.CW1.MicroservicesAPI._7461.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DSCC.CW1.MicroservicesAPI._7461.Controllers
{

		[Produces("application/json")]
		[Route("api/Pharmacy")]
		//[ApiController]
		public class PharmacyController : Controller
		{
			private readonly IPharmacyRepository _pharmacyRepository;
			public PharmacyController(IPharmacyRepository pharmacyRepository)
			{
				_pharmacyRepository = pharmacyRepository;

			}

			// GET: api/<MedicineController>
			[HttpGet]
			public IActionResult Get()
			{
				var pharmacies = _pharmacyRepository.GetPharmacies();
				return new OkObjectResult(pharmacies);
				//return new string[] { "value1",  "value2" };
			}

			// GET api/<MedicineController>/5
			[HttpGet("{id}", Name = "GetPharmacy")]
			public IActionResult Get(int id)
			{
				var pharmacy = _pharmacyRepository.GetPharmacyById(id);
				return new OkObjectResult(pharmacy);
			}

			// POST api/<MedicineController>
			[HttpPost]
			public IActionResult Post([FromBody] Pharmacy pharmacy)
			{
				using (var scope = new TransactionScope())
				{
					_pharmacyRepository.AddPharmacy(pharmacy);
					scope.Complete();
					return CreatedAtAction(nameof(Get), new { id = pharmacy.Id }, pharmacy);
				}

			}

			// PUT api/<MedicineController>/5
			[HttpPut("{id}")]
			public IActionResult Put(int Id,
							   [FromBody] Pharmacy pharmacy)
			{
				if (pharmacy!= null)
				{
					using (var scope = new TransactionScope())
					{
						_pharmacyRepository.UpdatePharmacy(pharmacy);
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
				_pharmacyRepository.DeletePharmacy(id);
				return new OkResult();
			}
		}
	
}
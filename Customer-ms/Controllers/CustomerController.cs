using Customer_ms.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Customer_ms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly List<CustomerViewModel> listCustomer =
            [
                new()
                {
                    id = 1,
                    code = "C001",
                    name = "Test",
                    phone = "989495881",
                    address = "Av. Alfonso Ugarte"
                },
                new()
                {
                    id = 2,
                    code = "C002",
                    name = "Test",
                    phone = "959462114",
                    address = "Av. Pardo"
                }

            ];

        [HttpGet]
        public ActionResult<IEnumerable<CustomerViewModel>> Get()
        {
            return Ok(listCustomer);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerViewModel> GetById(int id)
        {
            var customer = listCustomer.FirstOrDefault(x => x.id == id);
            if (customer is null) return NotFound();
            return Ok(customer);
        }
    }
}
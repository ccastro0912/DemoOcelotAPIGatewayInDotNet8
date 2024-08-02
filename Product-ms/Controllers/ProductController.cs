using Microsoft.AspNetCore.Mvc;
using Product_ms.ViewModels;

namespace Product_ms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly List<ProductViewModel> listProduct =
            [
                new()
                {
                    id = 1,
                    code = "P001",
                    name = "Test",
                },
                new()
                {
                    id = 2,
                    code = "P002",
                    name = "Test",
                }

            ];

        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> Get()
        {
            return Ok(listProduct);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductViewModel> GetById(int id)
        {
            var product = listProduct.FirstOrDefault(x => x.id == id);
            if (product is null) return NotFound();
            return Ok(product);
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentService _rentService;

        public RentalsController(IRentService rentManager)
        {
            _rentService = rentManager;
        }
        [HttpPost("add")]
        public IActionResult Add(Rent rent)
        {
            var result = _rentService.Add(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       /* [HttpGet("getrentdetail")]
        public IActionResult GetRentDetails()
        {
            var result = _rentService.GetRentDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }*/
    }
}

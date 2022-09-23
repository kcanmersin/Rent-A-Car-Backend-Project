using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbybrandid")]
        public IActionResult GetAllByBrandId(int brandId)
        {
            var result = _carService.GetAllByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbyunitprice")]
        public IActionResult GetAllByUnitPrice(int min, int max)
        {
            var result = _carService.GetByUnitPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }/*
        [HttpGet("getcarsdetails")]
        public IActionResult GetCarDetails(int carId )
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }*/
        [HttpGet("getcardetailbyid")]
        public IActionResult GetCarDetailById(int carId)
        {
            var result = _carService.GetCarById(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailbybrandid")]
        public IActionResult GetCarDetailsByBrandId(int brandId)
        {
            var result = _carService.GetCarDetailsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getcardetailbycolorid")]
        public IActionResult GetCarDetailsByColorId(int colorId)
        {
            var result = _carService.GetCarDetailsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getcardetailcolorandbrandid")]
        public IActionResult GetCarDetailsByColorAndBrandId(int colorId, int brandId)
        {
            var result = _carService.GetCarDetailsByColorAndBrandId(colorId,brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }






        [HttpGet("getallcarsdetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarId")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

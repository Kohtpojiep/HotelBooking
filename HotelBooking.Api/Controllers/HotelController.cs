using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Domain.IServices;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Validation;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Вывод всех продуктов, находящихся в базе данных
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Hotel> Get()
        {
            var hotel = _hotelService.GetAll();
            if (hotel == null)
                return NotFound();
            return new ObjectResult(hotel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            if (id < 1)
                ModelState.AddModelError("Error", "Неверный идентификатор");
            
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var hotel = _hotelService.GetById(id);
            if (hotel == null)
                return NotFound();
            return new ObjectResult(hotel);
        }

        /// <summary>
        /// Добавление продукта в базу данных
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Hotel> Post(Hotel hotel)
        {
            var validation = new HotelValidation().Validate(hotel);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            Hotel addedProduct;
            try
            {
                addedProduct = _hotelService.Add(hotel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return new ObjectResult(addedProduct);
        }

        /// <summary>
        /// Обновление данных продукта в базе данных
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(Hotel hotel)
        {
            var validation = new ProductValidation().Validate(hotel);
            if (validation.IsValid == false)
            {
                return BadRequest();
            }
            try
            {
                _hotelService.Update(hotel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        /// <summary>
        /// Удаление продукта из базы данных
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(Hotel hotel)
        {
            var validation = new ProductValidation().Validate(hotel);
            if (validation.IsValid == false)
            {
                return BadRequest();
            }
            try
            {
                _hotelService.Remove(hotel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}

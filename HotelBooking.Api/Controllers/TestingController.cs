using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Domain;
using HotelBooking.Domain.IRepositories;
using HotelBooking.Domain.IServices;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Validation;
using Newtonsoft.Json;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {

        /// <summary>
        /// А где это просматривается?...
        /// </summary>
        /// <param name="employeeService"></param>
        public TestingController( )
        {
            //_employeeService = employeeService;
        }

        /*
        /// <summary>
        /// Вывод всех продуктов, находящихся в базе данных
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Emloyee> Get()
        {
            var employee = _employeeService.GetAll().Result;
            if (employee == null)
                return NotFound();
            return new ObjectResult(employee);
        }
        /// <summary>
        /// Вывод продукта, который обладает данным идентификатором
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/{id}")]
        public ActionResult<Employee> Get(int id)
        {
            if (id < 1)
                ModelState.AddModelError("Error", "Неверный идентификатор");
            
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var employee = _employeeService.Get(id);
            if (employee == null)
                return NotFound();
            return new ObjectResult(employee);
        }

        /// <summary>
        /// Добавление продукта в базу данных
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            var validation = new EmployeeValidation().Validate(employee);
            if (validation.IsValid == false)
            {
                return BadRequest(validation.Errors);
            }
            Employee addedEmployee;
            try
            {
                addedEmployee = _employeeService.Add(employee).Result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return new ObjectResult(addedEmployee);
        }

        /// <summary>
        /// Обновление данных продукта в базе данных
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(Employee employee)
        {
            var validation = new EmployeeValidation().Validate(employee);
            if (validation.IsValid == false)
            {
                return BadRequest();
            }
            try
            {
                _employeeService.Update(employee);
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
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(Employee employee)
        {
            var validation = new EmployeeValidation().Validate(employee);
            if (validation.IsValid == false)
            {
                return BadRequest();
            }
            try
            {
                _employeeService.Remove(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        */
    }
}

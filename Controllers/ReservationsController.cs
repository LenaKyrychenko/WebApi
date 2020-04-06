using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Interfaces.SQLInterfaces.ISQLServices;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1.Entities.SQLEntities;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        #region Propertirs
        ISQLReservationsService _sqlReservationService;
        #endregion

        #region Constructors
        public ReservationsController(ISQLReservationsService sqlReservationService)
        {
            _sqlReservationService = sqlReservationService;
        }
            #endregion
        
            #region APIs
        // GET: Get all reservations
        [Route("Reservations")]
        [HttpGet]
        public IEnumerable<Reservations> Get()
        {
            return _sqlReservationService.GetAll();
        }

        // GET: Get reservations by id
        [Route("Reservations/{Id}")]
        [HttpGet]
        public Reservations Get(int Id)
        {
            return _sqlReservationService.GetAllById(Id);
        }

        // POST: Add new employee
        /*[Route("Employees")]
        [HttpPost]
        public long Post([FromBody]SQLEmployee employee)
        {
            return _sqlEmployeeService.AddEmployee(employee);
        }

        // PUT: Update existing employee
        [Route("Employee/{employee}")]
        [HttpPut]
        public void Put([FromBody]SQLEmployee employee)
        {
            _sqlEmployeeService.UpdateEmployee(employee);
        }*/

        // DELETE: Delete existing employee
        [Route("Reservations/{Id}")]
        [HttpDelete]
        public void Delete(int Id)
        {
            _sqlReservationService.DeleteAllById(Id);
        }
        #endregion
    }
}

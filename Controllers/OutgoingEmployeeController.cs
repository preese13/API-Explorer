using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using mockAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace mockAPI.Controllers {
    [Route ("[controller]")]
    public class OutgoingEmployeeController : Controller {
        private readonly IncomingEmployeeContext _context;

        public OutgoingEmployeeController (IncomingEmployeeContext context) {
            _context = context;
        }

        [ApiExplorerSettings (IgnoreApi = true)]
        public bool Authorize () {
            string auth = Request.Headers["Authorization"];
            if (auth == null) {
                return false;
            } else {
                if (auth.Contains (' ')) {
                    var token = auth.Split (' ') [1];
                    var from64 = Convert.FromBase64String (token);
                    var decoded = System.Text.Encoding.UTF8.GetString (from64);
                    if (decoded != "goodKey") {
                        return false;
                    } else {
                        return true;
                    }
                } else {
                    return false;
                }
            }
        }

        /// <summary>
        /// Adds an employee to the DB
        /// </summary>
        /// <response code="200">Product created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [ApiExplorerSettings (IgnoreApi = true)]
        [HttpPost ("Create")]
        public IActionResult Create ([FromBody] OutgoingEmployee Employee) {
            if (Authorize ()) {
                if (Employee == null) {
                    return BadRequest ();
                }

                IncomingEmployee newEmployee = new IncomingEmployee ();
                newEmployee.Address1 = Employee.Address1;
                newEmployee.Address2 = Employee.Address2;
                newEmployee.BirthDate = Employee.BirthDate;
                newEmployee.City = Employee.City;
                newEmployee.EmployeeId = Employee.EmployeeId;
                newEmployee.CompanyNumber = Employee.CompanyNumber;
                newEmployee.EmployeeStatus = new IncomingEmployeeStatus () {
                    EmployeeStatusCode = Employee.EmployeeStatus
                };
                newEmployee.TaxForm = Employee.TaxForm;
                newEmployee.FirstName = Employee.FirstName;
                newEmployee.LastName = Employee.LastName;
                newEmployee.Gender = Employee.Sex;
                newEmployee.HomePhone = Employee.HomePhone;
                newEmployee.MaritalStatus = Employee.MaritalStatus;
                newEmployee.MiddleName = Employee.MiddleName;
                newEmployee.SSN = Employee.ssn;
                newEmployee.PersonalEmailAddress = Employee.PersonalEmailAddress;

                _context.IncomingEmployees.Add (newEmployee);
                _context.SaveChanges ();
                return StatusCode (200);
            } else {
                return StatusCode (403);
            }

        }

        /// <response code="200">Product updated</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut ("Put/Company/{CompanyId}/Employee/{EmployeeId}")]
        public IActionResult Put ([FromBody] Partner1UpdateData updateEmployee, string CompanyId, string EmployeeId) {
            var localEmployee = updateEmployee.UpdateEmployee;
            if (Authorize ()) {
                if (updateEmployee == null) {
                    return BadRequest ();
                }

                var dbEmployee = _context.IncomingEmployees
                    .FirstOrDefault (t => t.EmployeeId == EmployeeId &&
                        t.CompanyNumber == CompanyId);

                if (dbEmployee == null) {
                    return NotFound ();
                }

                dbEmployee.Address1 = localEmployee.Address1;
                dbEmployee.Address2 = localEmployee.Address2;
                dbEmployee.BirthDate = localEmployee.BirthDate;
                dbEmployee.City = localEmployee.City;
                dbEmployee.EmployeeId = localEmployee.EmployeeId;
                dbEmployee.CompanyNumber = localEmployee.CompanyNumber;
                dbEmployee.EmployeeStatus = new IncomingEmployeeStatus () {
                    EmployeeStatusCode = localEmployee.EmployeeStatus
                };
                dbEmployee.TaxForm = localEmployee.TaxForm;
                dbEmployee.FirstName = localEmployee.FirstName;
                dbEmployee.LastName = localEmployee.LastName;
                dbEmployee.Gender = localEmployee.Sex;
                dbEmployee.HomePhone = localEmployee.HomePhone;
                dbEmployee.MaritalStatus = localEmployee.MaritalStatus;
                dbEmployee.MiddleName = localEmployee.MiddleName;
                dbEmployee.SSN = localEmployee.ssn;
                dbEmployee.PersonalEmailAddress = localEmployee.PersonalEmailAddress;

                _context.IncomingEmployees.Update (dbEmployee);
                _context.SaveChanges ();
                return StatusCode (200);
            } else {
                return StatusCode (403);
            }
        }
    }
}
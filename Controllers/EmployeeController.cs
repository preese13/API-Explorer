using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mockAPI.Models;
using System.Linq;
using System.Reflection;

namespace mockAPI.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool Authorize()
        {
            string auth = Request.Headers["Authorization"];
            if (auth == null)
            {
                return false;
            }
            else
            {
                if (auth.Contains(' '))
                {
                    var token = auth.Split(' ')[1];
                    var from64 = Convert.FromBase64String(token);
                    var decoded = System.Text.Encoding.UTF8.GetString(from64);
                    if (decoded != "goodKey")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        /// <response code="200">Product created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Employee Employee)
        {
            if (Authorize())
            {
                if (Employee == null)
                {
                    return BadRequest();
                }

                var dbEmployee = _context.Employees.FirstOrDefault(t => t.EmployeeId == Employee.EmployeeId);
                if (dbEmployee == null)
                {
                    _context.Employees.Add(Employee);
                    _context.SaveChanges();

                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(409);
                }
            }
            else
            {
                return StatusCode(403);
            }
        }


        /// <response code="200">Product fetched</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpGet("Get/Company/{CompanyId}/Employee/{EmployeeId}")]
        public IActionResult EmployeeId(string EmployeeId, string CompanyId)
        {
            if (Authorize())
            {
                var Employee1 = _context.Employees.FirstOrDefault(t => t.PayrollId == EmployeeId && t.CompanyId == CompanyId);
                if (Employee1 == null)
                {
                    return NotFound();
                }
                return new ObjectResult(Employee1);
            }
            else
            {
                return StatusCode(403);
            }
        }


        /// <response code="200">Product updated</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpPut("Put/Company/{CompanyId}/Employee/{EmployeeId}")]
        public IActionResult Put([FromBody] Employee Employee, string CompanyId, string EmployeeId)
        {
            if (Authorize())
            {
                if (Employee == null)
                {
                    return BadRequest();
                }

                var dbEmployee = _context.Employees.FirstOrDefault(t => t.PayrollId == Employee.PayrollId && t.CompanyId == CompanyId);
                if (dbEmployee == null)
                {
                    return NotFound();
                }

                dbEmployee.CompanyId = Employee.CompanyId;
                dbEmployee.PayrollId = Employee.PayrollId;
                dbEmployee.TimeClockId = Employee.TimeClockId;
                dbEmployee.SSN = Employee.SSN;
                dbEmployee.FirstName = Employee.FirstName;
                dbEmployee.MiddleName = Employee.MiddleName;
                dbEmployee.LastName = Employee.LastName;
                dbEmployee.Suffix = Employee.Suffix;
                dbEmployee.DOB = Employee.DOB;
                dbEmployee.Gender = Employee.Gender;
                dbEmployee.MaritalStatus = Employee.MaritalStatus;
                dbEmployee.PayrollGroup = Employee.PayrollGroup;
                dbEmployee.PayFrequency = Employee.PayFrequency;
                dbEmployee.BusinessUnit = Employee.BusinessUnit;
                dbEmployee.Office = Employee.Office;
                dbEmployee.Department = Employee.Department;
                dbEmployee.Division = Employee.Division;
                dbEmployee.Union = Employee.Union;
                dbEmployee.JobTitle = Employee.JobTitle;
                dbEmployee.FullTime = Employee.FullTime;
                dbEmployee.StatutoryClass = Employee.StatutoryClass;
                dbEmployee.Seasonal = Employee.Seasonal;
                dbEmployee.AcaClassification = Employee.AcaClassification;
                dbEmployee.HireDate = Employee.HireDate;
                dbEmployee.OriginalHireDate = Employee.OriginalHireDate;
                dbEmployee.EmploymentStatus = Employee.EmploymentStatus;
                dbEmployee.WorkerTaxStatus = Employee.WorkerTaxStatus;
                dbEmployee.TerminationDate = Employee.TerminationDate;
                dbEmployee.TerminationReason = Employee.TerminationReason;
                dbEmployee.PayEffectiveDate = Employee.PayEffectiveDate;
                dbEmployee.CompensationBasis = Employee.CompensationBasis;
                dbEmployee.AnnualBaseSalary = Employee.AnnualBaseSalary;
                dbEmployee.BaseHourlyRate = Employee.BaseHourlyRate;
                dbEmployee.HoursPerWeek = Employee.HoursPerWeek;
                dbEmployee.AnnualBenefitSalary = Employee.AnnualBenefitSalary;
                dbEmployee.Address1 = Employee.Address1;
                dbEmployee.Address2 = Employee.Address2;
                dbEmployee.Address3 = Employee.Address3;
                dbEmployee.City = Employee.City;
                dbEmployee.County = Employee.County;
                dbEmployee.Email = Employee.Email;
                dbEmployee.Phone = Employee.Phone;
                dbEmployee.State = Employee.State;
                dbEmployee.ZIP = Employee.ZIP;

                _context.Employees.Update(dbEmployee);
                _context.SaveChanges();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}

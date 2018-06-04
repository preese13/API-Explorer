using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mockAPI.Models;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace mockAPI.Controllers
{

    public class DeductionController : Controller
    {

        private readonly DeductionContext _context;

        public DeductionController(DeductionContext context)
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
        [HttpPost("[controller]/Create")]
        public IActionResult Create([FromBody] Deduction Deduction)
        {

            if (Authorize())
            {
                if (Deduction == null)
                {
                    return BadRequest();
                }

                var dbDeduction = _context.Deductions.FirstOrDefault(t => t.DeductionCode == Deduction.DeductionCode);
                if (dbDeduction == null)
                {

                    _context.Deductions.Add(Deduction);
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
        [HttpGet("[controller]/Get/{DeductionCode}")]
        public IActionResult GetById(string DeductionCode)
        {
            if (Authorize())
            {
                var deduction = _context.Deductions.FirstOrDefault(t => t.DeductionCode == DeductionCode);
                if (deduction == null)
                {
                    return NotFound();
                }
                return new ObjectResult(deduction);
            }
            else
            {
                return StatusCode(403);
            }
        }


        /// <response code="200">Product updated</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [HttpPut("[controller]/Put/{DeductionCode}")]
        public IActionResult Put([FromBody] Deduction deduction, string DeductionCode)
        {

            if (Authorize())
            {
                if (deduction == null)
                {
                    return BadRequest();
                }

                var dbDeduction = _context.Deductions.FirstOrDefault(t => t.EmployeeId == deduction.EmployeeId);
                if (dbDeduction == null)
                {
                    return NotFound();
                }

                dbDeduction.CompanyId = deduction.CompanyId;
                dbDeduction.PayrollId = deduction.PayrollId;
                dbDeduction.Benefit = deduction.Benefit;
                dbDeduction.IsPostTax = deduction.IsPostTax;
                dbDeduction.DeductionFrequency = deduction.DeductionFrequency;
                dbDeduction.TypeOfDeduction = deduction.TypeOfDeduction;
                dbDeduction.EmployeePerPayAmount = deduction.EmployeePerPayAmount;
                dbDeduction.EmployerPerPayAmount = deduction.EmployerPerPayAmount;
                dbDeduction.EmployeeMonthlyAmount = deduction.EmployeeMonthlyAmount;
                dbDeduction.EmployerMonthlyAmount = deduction.EmployerMonthlyAmount;
                dbDeduction.DeductionPercentage = deduction.DeductionPercentage;
                dbDeduction.EnrollmentStartDate = deduction.EnrollmentStartDate;
                dbDeduction.DeductionStartDate = deduction.DeductionStartDate;
                dbDeduction.EnrollmentEndDate = deduction.EnrollmentEndDate;
                dbDeduction.PlanYearBegin = deduction.PlanYearBegin;
                dbDeduction.PlanYearEnd = deduction.PlanYearEnd;
                dbDeduction.ModifiedDate = deduction.ModifiedDate;

                _context.Deductions.Update(dbDeduction);
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

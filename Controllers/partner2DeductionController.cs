using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mockAPI.Models;
using System.Linq;

namespace mockAPI.Controllers
{
    [Route("[controller]")]
    public class Partner2DeductionController : Controller
    {
        private readonly DeductionContext _context;

        public Partner2DeductionController(DeductionContext context)
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
        [HttpPost("Create/{Dcode}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create([FromBody] Partner2Deduction Deduction, string Dcode)
        {
            if (Authorize())
            {
                if (Deduction == null)
                {
                    return BadRequest();
                }

                Deduction newDeduction = new Deduction();
                newDeduction.DeductionCode = Dcode;
                newDeduction.EmployeePerPayAmount = Deduction.Amount;
                newDeduction.DeductionPercentage = Deduction.Rate;
                _context.Deductions.Add(newDeduction);
                _context.SaveChanges();

                return StatusCode(200);
            }
            else
            {
                return StatusCode(403);
            }
        }

        /// <response code="200">Product updated</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Put([FromBody] Partner2Deduction deduction, string Dcode)
        {
            if (Authorize())
            {
                if (deduction == null)
                {
                    return BadRequest();
                }

                var dbDeduction = _context.Deductions.FirstOrDefault(t => t.DeductionCode == Dcode);
                if (dbDeduction == null)
                {
                    return NotFound();
                }

                dbDeduction.EmployeePerPayAmount = deduction.Amount;
                dbDeduction.DeductionPercentage = deduction.Rate;
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



//get method used for testing
/* 
        [HttpGet("{DeductionCode}")]
        public IActionResult GetById(string DeductionCode)
        {
            string auth = Request.Headers["Authorization"];
            if (auth == null)
            {
                return StatusCode(403);
            }
            else
            {
                var from64 = Convert.FromBase64String(auth);
                var decoded = System.Text.Encoding.UTF8.GetString(from64);

                if (decoded != "goodKey")
                {
                    return StatusCode(401);
                }
                else
                {
                    var deduction = _context.Partner1Deductions.FirstOrDefault(t => t.Dcode == DeductionCode);

                    if (deduction == null)
                    {
                        return StatusCode(404);
                    }

                    return new ObjectResult(deduction);
                }
            }
        }
*/

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mockAPI.Models;
using System.Linq;
using System.Reflection;

namespace mockAPI.Controllers
{
    [Route("[controller]")]
    public class Partner1DeductionController : Controller
    {
        private readonly DeductionContext _context;

        public Partner1DeductionController(DeductionContext context)
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
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Create([FromBody] Partner1Deduction Deduction)
        {
            if (Authorize())
            {
                if (Deduction == null)
                {
                    return BadRequest();
                }

                Deduction newDeduction = new Deduction();

                int toNum = Int32.Parse(Deduction.EmployeeId);
                newDeduction.DeductionCode = Deduction.Dcode;
                newDeduction.EmployeeId = toNum;

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
        [HttpPut("Put")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Put([FromBody] Partner1Deduction deduction)
        {
            if (Authorize())
            {
                if (deduction == null)
                {
                    return BadRequest();
                }

                var dbDeduction = _context.Deductions.FirstOrDefault(t => t.DeductionCode == deduction.Dcode);
                if (dbDeduction == null)
                {
                    return NotFound();
                }

                dbDeduction.DeductionCode = deduction.Dcode;
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


//Get Method Used for testing
/* 
        [HttpGet]
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

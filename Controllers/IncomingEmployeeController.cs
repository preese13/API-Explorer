using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using mockAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mockAPI.Controllers {
    [Route ("[controller]")]
    public class IncomingEmployeeController : Controller {
        private readonly IncomingEmployeeContext _context;

        public IncomingEmployeeController (IncomingEmployeeContext context) {
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

        /// <response code="200">Product fetched</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        [ApiExplorerSettings (IgnoreApi = true)]
        [HttpGet ("Get/Company/{CompanyId}/Employee/{EmployeeId}")]
        public IActionResult GetById (string CompanyId, string EmployeeId) {
            if (Authorize ()) {
                var Employee1 = _context.IncomingEmployees
                    .Include (i => i.DepartmentPosition)
                    .Include (p => p.PrimaryPayRate)
                    .FirstOrDefault (t => t.EmployeeId == EmployeeId &&
                        t.CompanyNumber == CompanyId);
                if (Employee1 == null) {
                    return NotFound ();
                }
                return new ObjectResult (Employee1);
            } else {
                return StatusCode (403);
            }

        }
    }
}
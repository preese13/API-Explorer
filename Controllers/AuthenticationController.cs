using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mockAPI.Models;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.JsonPatch;

namespace mockAPI.Controllers
{

    [Route("[controller]")]
    public class AuthenticationController : Controller
    {

        [HttpGet("Authenticate")]
        [HttpPost("Authenticate")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Authenticate()
        {

            string auth = Request.Headers["Authorization"];
            if (auth == null)
            {
                return StatusCode(403);
            }
            else if (auth.Contains(' '))
            {
                var token = auth.Split(' ')[1];
                var from64 = Convert.FromBase64String(token);
                var decoded = System.Text.Encoding.UTF8.GetString(from64);

                if (decoded.Contains(':'))
                {
                    var apiKey = decoded.Split(':')[0];
                    var secretKey = decoded.Split(':')[1];

                    if (apiKey != "myApiKey" || secretKey != "mySecretKey")
                    {
                        return StatusCode(401);
                    }
                    else if (apiKey == "myApiKey" && secretKey == "mySecretKey")
                    {
                        var to64 = System.Text.Encoding.UTF8.GetBytes("goodKey");
                        var base64 = Convert.ToBase64String(to64);

                        return Json(new { AccessToken = base64 });
                    }
                    else
                    {
                        return StatusCode(401);
                    }
                }
                else
                {
                    return StatusCode(403);
                }
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}
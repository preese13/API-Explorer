using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FluentEmail.Mailgun;
using mockAPI.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mockAPI.Controllers {
    public class DocumentationController : Controller {
        private readonly UserContext _context;

        public DocumentationController (UserContext context) {
            _context = context;
        }

        public bool Authorize () {
            string cookieValueFromReq = Request.Cookies["sessionID"];

            if (cookieValueFromReq != null) {
                var from64 = Convert.FromBase64String (cookieValueFromReq);
                var decoded = System.Text.Encoding.UTF8.GetString (from64);

                if (decoded != "authorizationKey") {
                    return false;
                } else {
                    return true;
                }
            } else {
                return false;
            }
        }

        public IActionResult openSwagger () {
            var file = Path.Combine (Directory.GetCurrentDirectory (),
                "api", "index.html");

            return PhysicalFile (file, "text/html");
        }
        public void createSessionCookie () {
            var to64 = System.Text.Encoding.UTF8.GetBytes ("authorizationKey");
            var base64 = Convert.ToBase64String (to64);

            CookieOptions options = new CookieOptions ();
            options.Expires = DateTime.Now.AddDays (1);
            options.HttpOnly = true;
            options.SameSite = SameSiteMode.Strict;

            Response.Cookies.Append ("sessionID", base64, options);
        }

        public void addUser (string email, string password) {
            User User = new User () {
                Email = email,
                Password = Hash (password),
            };

            _context.Users.Add (User);
            _context.SaveChanges ();
        }

        public bool SignupForm (string email, string password, string accessCode) {
            if (accessCode != null) {
                try {
                    var from64 = Convert.FromBase64String (accessCode);
                    var decoded = System.Text.Encoding.UTF8.GetString (from64);
                    if (!decoded.Contains (':')) {
                        return false;
                    } else {
                        var apiKey = decoded.Split (':') [0];
                        var secretKey = decoded.Split (':') [1];

                        if (apiKey != "myApiKey" || secretKey != "mySecretKey") {
                            return false;
                        } else {
                            var checkUser = _context.Users.FirstOrDefault (t => t.Email == email);
                            if (checkUser != null) {
                                return false;
                            } else {
                                return true;
                            }
                        }
                    }
                } catch {
                    return false;

                }
            } else {
                return false;

            }
        }

        public bool LoginForm (string email, string password) {
            var checkUser = _context.Users.FirstOrDefault (t => t.Email == email);

            if (checkUser != null && checkUser.Password == Hash (password)) {
                return true;
            } else {
                return false;

            }
        }

        public string Hash (string password) {
            byte[] salt = new byte[128 / 8];

            string hashed = Convert.ToBase64String (KeyDerivation.Pbkdf2 (
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1000,
                numBytesRequested: 128 / 8));

            return hashed;
        }

        public IActionResult Index () {
            if (Authorize ()) {
                return View ();

            } else {

                return RedirectToAction ("LoginError", "Documentation");

            }

        }

        public IActionResult Login () {

            return View ();
        }

        public IActionResult LoginError () {
            return View ();
        }

        [HttpPost]
        public IActionResult Login (string email, string password) {
            if (LoginForm (email, password)) {
                createSessionCookie ();
                return openSwagger ();
            } else {
                return View ("../Documentation/LoginError");
            }
        }

        [HttpPost]
        public IActionResult LoginError (string email, string password) {
            if (LoginForm (email, password)) {
                createSessionCookie ();
                return openSwagger ();
            } else {
                return View ("../Documentation/LoginError");

            }
        }

        public IActionResult Swagger () {
            if (Authorize ()) {
                return openSwagger ();
            } else {
                return RedirectToAction ("LoginError", "Documentation");
            }

        }
        public IActionResult apiResources () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult apiTestingExpectations () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult BusinessProcessRequirements () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult Download () {
            if (Authorize ()) {
            var file = Path.Combine (Directory.GetCurrentDirectory (),
                "api", "fakeDocs.pdf");

            return PhysicalFile (file, "application/pdf");

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult DeductionRecord () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult DeductionResponse () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult EmployeeNavigatorClasses () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult EmployeeNavigatorOverview () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult EmployeeNavigatorResources () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult EmployeeRecords () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult EmployeeResponse () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult EmployeeResultObject () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult HandlingMultipleEINs () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult IntegrationRequirements () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult NotificationResponse () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult Overview () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult PayrollPartnerEmployeeNotification () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult PayrollPartnerResources () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult ProductFunctionality () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult RequiredProductDevelopmentWork () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

        public IActionResult Updates () {
            if (Authorize ()) {
                return View ();

            } else {
                return RedirectToAction ("LoginError", "Documentation");

            }
        }

    }
}
/*
public IActionResult Signup () {
    return View ();
}
public IActionResult SignupError () {
    return View ();
}

[HttpPost]
public IActionResult Signup (string email, string password, string accessCode) {

    if (SignupForm (email, password, accessCode)) {

        createSessionCookie ();
        addUser (email, password);
        return openSwagger ();
    } else {
        return View ("../Documentation/SignupError");
    }

}

        [HttpPost]
        public IActionResult SignupError (string email, string password, string accessCode) {
            if (SignupForm (email, password, accessCode)) {
                createSessionCookie ();
                addUser (email, password);
                return openSwagger ();
            } else {
                return View ("../Documentation/SignupError");
            }
        }

         */
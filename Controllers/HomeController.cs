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
    public class HomeController : Controller {
        private readonly UserContext _context;

        public HomeController (UserContext context) {
            _context = context;
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

        public IActionResult Index () {

            return View ();
        }

        [HttpPost]
        public IActionResult Index (string email, string password) {
            if (LoginForm (email, password)) {
                createSessionCookie ();
                return openSwagger ();
            } else {
                return RedirectToAction ("LoginError", "Documentation");
            }
        }



    }
}
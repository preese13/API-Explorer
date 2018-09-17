
To make postmant requests:
    
    Header needed to hit authentication endpoint: Bearer bXlBcGlLZXk6bXlTZWNyZXRLZXk=
    Authorization header when making requests to any other endpoint: Z29vZEtleQ==


Some notes:

AUTHORIZATION / AUTHENTICATION:

I first attempted to use some standard .net core implementations:

https://www.jerriepelser.com/blog/authenticate-oauth-aspnet-core-2/
https://docs.microsoft.com/en-us/aspnet/core/security/authorization/simple?view=aspnetcore-2.1
https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-2.1
https://docs.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased?view=aspnetcore-2.1&tabs=aspnetcore2x
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.1&tabs=visual-studio%2Caspnetcore2x


long story short:  at their worst the documentation was outdated and thus kind of useless, at their best they overwrote large portions of files that blew up what I had already written.  With the implementations that blew up what I had, I cloned the project into another folder, allowed the implementation to overwrite files in one so I could attempt to stitch it together/write it myself in the second folder.  Eventually I decided that it was more trouble than it was worth so I found another way.

I landed on a system that prompts users to create/login to an account, that will give them a cookie with a session ID that allows them to access the swagger documentation via a check in the controller.

In order to be sure that not anyone can sign up for an account, I added a third field to the signup form (accessCode) in the form of a base64 string used in the authentication controller.

If a user with the accesscode creates a user with a unique username they will be given this cookie:
        public void createSessionCookie()
        {
            var to64 = System.Text.Encoding.UTF8.GetBytes("authorizationKey");
            var base64 = Convert.ToBase64String(to64);

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            options.HttpOnly = true;
            options.SameSite = SameSiteMode.Strict;

            Response.Cookies.Append("sessionID", base64, options);
        }
they will be added to the user database, their password will be hashed with the following function:
        public string Hash(string password)
        {
            byte[] salt = new byte[128 / 8];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1000,
                numBytesRequested: 128 / 8));

            return hashed;
        }

each of the views where it is necessary (excluding login/signup pages) will check for the cookie, returning the view if it is there and kicking them out to an invalid access/sign in page if it is not
        public bool Authorize()
        {
            string cookieValueFromReq = Request.Cookies["sessionID"];

            if (cookieValueFromReq != null)
            {
                var from64 = Convert.FromBase64String(cookieValueFromReq);
                var decoded = System.Text.Encoding.UTF8.GetString(from64);

                if (decoded != "authorizationKey")
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

the login/signup pages contain a form that makes a post request to the controller.  they are two separate files as a quick fix to some issues I had with making very similar post requests to the same controller.  There are also login/signupError pages, which are a temporary solution for pushing partial views to the pages.
The pages are also written in (temporary) inline styles, as they were a late addition to the project and I didn't want to hook them up to the _layout page


SERVING THE SWAGGER DOCUMENT:

All swagger information is currently contained in the api folder for the following reasons:

-anything in the wwwroot file is served to the client using "app.UseStaticFiles();" as per the .net core documentation:
"The static file middleware doesn't provide authorization checks. Any files served by it, including those under wwwroot, are publicly accessible."

In order to add an authentication check, I declared a path to serve static files in startup.cs:
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "api")),
                RequestPath = "/Api",
            });
    
then in my controller, after my authorization check, return the swagger document when needed:

        public IActionResult openSwagger()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(),
                "api", "index.html");

            return PhysicalFile(file, "text/html");
        }

THE SWAGGER DOCUMENT:

The swagger document is rendered inside the #swagger-ui element in the index page.  
there are accompanying .js and .js.map files that specify how the doc is rendered, but it was taking me too long to acheive what I want so I went in another direction:

I knew that I could predict the id's and classes of the html elements on the page based on the names of models/controllers in the API, so I wrote a custom.css file 
to customize the docs.

at this point I'll be describing some of the visual components of the project and seeing it is probably helpful: 

http://localhost:5000/Documentation/Signup

access code: bXlBcGlLZXk6bXlTZWNyZXRLZXk=

you will be navigated to the "Definitions" section, where a katherine approved what/why will be given for various endpoints

the navbar also has a section for endpoints, models, documentation, and an authorize button.

clicking the endpoints / models links will hide any other sections on the page and display the corresponding section from the swagger doc, 
giving the site the feel of having multiple pages while operating as an SPA.  

the authorize button is from the swagger doc and was given a fixed position to keep it in the navbar at all times, but it will dissapear when navigating to an MVC page (see below)

clicking the documentation link will open a separate section that serves up the previously existing documentation in more of an MVC format (documentation controller).
models were deliberately left out of the traditional mvc pattern to avoid polluting the API spaces/swaggerdoc with view related content as much as possible.

the swagger document ignores  the authentication and partner specific endpoints as the former isnt really necessary for a developer to learn how the API works and the latter is duh.  The swagger middleare does allow for you to specify different swagger documents and point different enpoints to each of them, but it does not allow me to restrict access to them in any meaningfiul way, so I just ignored those endpoints.


NAVIGATION:
navigation within the "swagger" pages is smple: use jquery to trigger css classes that hide/display specific elements on click.
navigating TO the swagger document FROM other pages had an issue:  whenever the user navigates to a swagger page from an MVC page, it opens to its 
default section (Definitions). but, sometimes the user is navigating to a separate section, eg: models. so its obviously a problem that when the page is loaded it always goes
to its defaults.  

In /api/custom.js I use the browser open the specific section requested by the client.  whenever a link is clicked, it is logged in the browser's
sesseion storage via a numerical value:

        sessionStorage.setItem("clickedLink", 2); 

whenever a page loads, it immediately checks the browser to check from which link the navigation occured:

    var clickedLink = sessionStorage.getItem("clickedLink");

from there its a simple if-else flow to trigger the proper css classes, with a setTimeout function added to give swagger some time to populate the dom 


known bugs/things in the works:

"invalid access rights" is given as without more information: eg: incorrect password, will be fixed with the addition of partial views to the login/error pages

in the endpoints section: when an endpoint title is clicked on (eg: deduction) it dissapears and will not reload unless the apge is loaded.  It is a result of separating the swaggerdoc into multiple pages.  Attempted to fix in in JS/CSS (where I made the changes) but no luck.  Will give it a go again in case it was my error

obviously gonna restructure the login pages HTML as a whole, and change the defaults on the inputs so they dont look so ugly when you use them

if you add the authorization key to requests via the button in the top corner, it will be lost when you navigate to the documentation section as it is a new page.  not much that can be done about it besides informing you when you plug it in

navigate to localhost:5000/swagger and you will see another version of the swaggerdoc.... there's nothing I know of that can get rid of.  It is a result of the middleware and as far as I have seen cant be blocked.  I tried creating other files to sit on top of and this block it, I tried redirecting it with a controller, I tried creating a page/controller to block it as well, and I tried getting around the app.use static files that serves it up.  no dice.  any notes/ideas as to how something could be done about that are welcome.  There are no links to navigate to it, and all webcrawlers are blocked from the entire project so It isnt too much of an issue, but it bothers me after spending the time to secure the application.









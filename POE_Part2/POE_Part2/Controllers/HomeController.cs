using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using POE_Part2.Data;
using POE_Part2.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace POE_Part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClaimDbContext _context;

        public HomeController(ILogger<HomeController> logger, ClaimDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Check the database for a matching user with the provided username and password.
            var user = _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }

            // Set up the user identity after successful login.
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");

            // Sign in the user
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("ClaimSubmission"); // Redirect to the claim submission page
        }


        [HttpGet]
        public IActionResult ClaimSubmission()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClaimSubmission(LecturerClaim claim, IFormFile supportingDocument)
        {
            if (ModelState.IsValid) {
                if (supportingDocument != null && supportingDocument.Length > 0)
                {
                    //unique filename to prevent overwriting
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(supportingDocument.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await supportingDocument.CopyToAsync(stream);
                    }
                    claim.SupportingDocument = uniqueFileName; // save the unique file name in the database
                }

                claim.Status = "Pending";
                claim.SubmittedDate = DateTime.Now;
                // Save claim to database
                _context.Claims.Add(claim);
                _context.SaveChanges(); // inserts the claim into database
                return RedirectToAction("ClaimSuccess"); //redirects to a confirmation page
            }
            return View(claim);
        }

        public int GetLoggedInLecturerId()
        {
            //User.Identity.Name holds the lecturer's username or email
            var user = User.Identity?.Name; // Get the username or email of the logged-in user
            
            if (string.IsNullOrEmpty(user))
            {
                _logger.LogError("User identity not found");
                throw new Exception("User identity not found.");
            }
            // Query the database to get the Lecturer's ID based on their username or email
            var lecturer = _context.Users.FirstOrDefault(u => u.Name == user && u.Role == "Lecturer");

            if (lecturer != null)
            {
                return lecturer.UserId; // Return the Lecturer's ID
            }

            _logger.LogError($"Lecturer not found for user: {user}");
            throw new Exception("Lecturer not found");
        }

        public IActionResult ViewClaim()
        {
            // Assuming you have a method to get the current logged-in lecturer's ID
            int lecturerId = GetLoggedInLecturerId();

            // Fetch claims submitted by the lecturer
            var claims = _context.Claims.Where(c => c.LecturerId == lecturerId).ToList();

            return View(claims);
        }

        public IActionResult ClaimApproval()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

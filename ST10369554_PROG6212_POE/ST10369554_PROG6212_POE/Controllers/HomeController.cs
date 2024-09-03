using Microsoft.AspNetCore.Mvc;
using ST10369554_PROG6212_POE.Models;
using System.Diagnostics;

namespace ST10369554_PROG6212_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

         private static List<Claim> claims = new List<Claim>();

            // GET: Claim/Create
            public ActionResult SubmitClaim()
            {
                return View();
            }

            // POST: Claim/Create
            [HttpPost]
            public ActionResult SubmitClaim(Claim claim)
            {
                if (ModelState.IsValid)
                {
                    claim.Id = claims.Count + 1;
                    claim.Status = ClaimStatus.Submitted;
                    claims.Add(claim);

                    return RedirectToAction("AddedClaims");
                }

                return View(claim);
            }

            // GET: Claim/MyClaims
            public ActionResult AddedClaims()
            {
                var lecturerClaims = claims.Where(c => c.LecturerId == User.Identity.Name).ToList();
                return View(lecturerClaims);
            }

            // GET: Claim/Approve
            public ActionResult Approve(int id)
            {
                var claim = claims.FirstOrDefault(c => c.Id == id);
                return View(claim);
            }

            // POST: Claim/Approve
            [HttpPost]
            public ActionResult Approve(int id, string managerComments, bool approve)
            {
                var claim = claims.FirstOrDefault(c => c.Id == id);

                if (claim != null)
                {
                    claim.ManagerComments = managerComments;
                    claim.Status = approve ? ClaimStatus.Approved : ClaimStatus.Rejected;

                    return RedirectToAction("ApprovalPending");
                }

                return View(claim);
            }

            // GET: Claim/PendingApprovals
            public ActionResult PendingApprovals()
            {
                var pendingClaims = claims.Where(c => c.Status == ClaimStatus.Submitted).ToList();
                return View(pendingClaims);
            }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using AspNetCore;
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

        // GET: Claim/Submit Claim
            public ActionResult SubmitClaim()
            {
                return View();
            }

            // POST: Claim/Submit Claim
            [HttpPost]
            public async Task<ActionResult> SubmitClaim(Claim claim, IFormFile supportingDocument)
            {
                if (ModelState.IsValid)
                {
                //Save uploaded file
                if (supportingDocument != null && supportingDocument.Length > 0)
                {
                    var allowedExtensions = new[] { ".pdf", ".docx", "xlsx" };
                    var extension = Path.GetExtension(supportingDocument.FileName);
                    if (allowedExtensions.Contains(extension.ToLower()) && supportingDocument.Length < 5 * 1024 * 1024)// 5 MB size limit
                    { 
                        var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/uploads", supportingDocument.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await supportingDocument.CopyToAsync(stream);
                        }
                        claim.SupportingDocumentPath = "/uploads/" + supportingDocument.FileName;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid file type or size.");
                        return View(claim);
                    }
                }
                    claim.ClaimId = claims.Count + 1;
                    claim.Status = ClaimStatus.Submitted;
                    claim.Total = claim.HoursWorked * claim.HourlyRate;
                    claim.GrandTotal = claim.Total;
                    claim.ClaimDate = DateTime.Now;

                    claims.Add(claim);
                    return RedirectToAction("AddedClaims");
                }

                return View(claim);
            }

            // GET: Claim/AddedClaims
            public ActionResult AddedClaims()
            {
                var lecturerClaims = claims.Where(c => c.LecturerId == User.Identity.Name).ToList();
                return View(lecturerClaims);
            }

            // GET: Claim/Approve
            public ActionResult Approve(int id)
            {
                var claim = claims.FirstOrDefault(c => c.ClaimId == id);
                return View(claim);
            }

            // POST: Claim/Approve
            [HttpPost]
            public ActionResult Approve(int id, string managerComments, bool approve)
            {
                var claim = claims.FirstOrDefault(c => c.ClaimId == id);

                if (claim != null)
                {
                    claim.ManagerFeedback = managerComments;
                    claim.Status = approve ? ClaimStatus.Approved : ClaimStatus.Rejected;

                    return RedirectToAction("ApprovalPending");
                }

                return View(claim);
            }

            // GET: Claim/PendingApprovals
            public ActionResult ApprovalPending()
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

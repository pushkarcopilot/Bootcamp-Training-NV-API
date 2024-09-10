
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngagementController : Controller
    {
        private readonly IEngagementRepository _engagementRepository;

        public EngagementController(IEngagementRepository engagementRepository)
        {
            _engagementRepository = engagementRepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[Route("Add")]
        //public string Add()
        //{
        //    _engagementRepository.AddEngagement("Acme Corp", DateTime.Now, DateTime.Now.AddMonths(1), 5, new List<int>() { 1, 2, 3 }, AuditTypeId.FinancialAudit, EngagementStatusId.Assigned);

        //    return "ok";
        //}

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateAsync([FromBody] Engagement data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _engagementRepository.AddEngagement(data);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            // Sample code, Please replace this using your own

            var engagements = _engagementRepository.GetAllEngagements();

            return new JsonResult(engagements);
        }
    }
}

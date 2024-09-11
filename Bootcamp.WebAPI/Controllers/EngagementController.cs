using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("Add")]
        public string Add()
        {
            _engagementRepository.AddEngagement("Acme Corp", DateTime.Now, DateTime.Now.AddMonths(1), 5, new List<int>() { 1, 2, 3 }, AuditTypeValue.FinancialAudit, EngagementStatusValue.Completed);

            return "ok";
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Engagement>>> GetEngagements()
        {
            var engagements = await _engagementRepository.GetAllEngagements();

            if (engagements == null || !engagements.Any())
            {
                return NotFound();
            }

            return Ok(engagements);
        }

        [HttpPost]
        [Route("AddBackupSetting")]
        public string AddBackupSetting([FromBody] AddBackupSettingPayload payload)
        {
            try
            {
                _engagementRepository.AddBackupSettings(payload.BackupFrequency);

                return "ok";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return "not okay";
            }
        }
    }
}

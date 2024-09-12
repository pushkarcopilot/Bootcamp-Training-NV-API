
using Azure.Core;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Bootcamp.Data.Models;
using FluentValidation;
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

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateEngagement([FromBody] Engagement engagement, IValidator<Engagement> validator)
        {
            try
            {
                var validationResult = validator.Validate(engagement);
                if (validationResult.IsValid)
                {
                    _engagementRepository.AddEngagement(engagement);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpGet]
        [Route("GetEngagementByEngagementId")]

        public async Task<ActionResult> GetEngagementByEngagementId(int EngagementId)
        {
            try
            {
                //var response = await _IClientDetailsService.GetClientsDetailsAsync(EngagementId);
                var response = await _engagementRepository.GetEngagementById(EngagementId);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch
            {
                throw;
            }
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

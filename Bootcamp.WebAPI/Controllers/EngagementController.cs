
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
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
        public async Task<ActionResult<IEnumerable<Engagement>>> GetEngagements()
        {
            var engagements = await _engagementRepository.GetAllEngagements();

            if (engagements == null || !engagements.Any())
            {
                return NotFound();
            }

            return Ok(engagements);
        }
    }
}

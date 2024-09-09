using Bootcamp.Data.Interface;
using Bootcamp.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewEngagementController : ControllerBase
    {
        private readonly IClientDetailsService _IClientDetailsService;

        public ViewEngagementController(IClientDetailsService IClientDetailsService)
        {
            this._IClientDetailsService = IClientDetailsService;
        }

        [HttpGet]
        [Route("GetEngagementByEngagementId")]


        public async Task<ActionResult> GetEngagementByEngagementId(int EngagementId)
        {
            try
            {
                var response = await _IClientDetailsService.GetClientsDetailsAsync(EngagementId);
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

        [HttpGet]
        [Route("Countries")]
        public List<LEV_Countries> GetCountries()
        {
            try
            {
                var response = _IClientDetailsService.GetCountries().ToList();
                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("AuditStatus")]
        public List<LEV_AuditStatus> GetAuditStatus()
        {
            try
            {
                var response = _IClientDetailsService.GetAuditStatus().ToList();
                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("AuditTypes")]
        public List<LEV_AuditTypes> GetAuditTypes()
        {
            try
            {
                var response = _IClientDetailsService.GetAuditTypes().ToList();
                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("Auditors")]
        public List<LEV_Auditors> GetAuditors()
        {
            try
            {
                var response = _IClientDetailsService.GetAudiors().ToList();
                return response;
            }
            catch
            {
                throw;
            }
        }
    }

}

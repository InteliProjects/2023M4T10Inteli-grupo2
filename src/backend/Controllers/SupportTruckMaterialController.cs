using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BackendECOTVOS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupportTruckMaterialController : ControllerBase
    {
        private readonly ISupportTruckMaterialService _supportTruckMaterialService;

        public SupportTruckMaterialController(ISupportTruckMaterialService supportTruckMaterialAssignmentService)
        {
            _supportTruckMaterialService = supportTruckMaterialAssignmentService;
        }

        [HttpPost("AddSupportTruckMaterial")]
        public async Task<IActionResult> AddSupportTruckMaterial(MaterialAssignmentViewModel mat)
        {
            try
            {
                int newMatAsignId = await _supportTruckMaterialService.AddSupportTruckMaterial(mat);
                string resourceUrl = $"/material/{newMatAsignId}";

                return Created(resourceUrl, null);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to add support truck material (Controller). Exception: " + e.Message);
            }

        }

        [HttpDelete("RemoveSupportTruckMaterial")]
        public async Task<IActionResult> RemoveSupportTruckMaterial(MaterialAssignmentViewModel mat)
        {
            try
            {
                await _supportTruckMaterialService.RemoveSupportTruckMaterial(mat);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest("Failed to remove support truck material (Controller). Exception: " + e.Message);
            }

        }
    }
}

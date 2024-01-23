using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendECOTVOS.Services.Interfaces;
using BackendECOTVOS.Domain.ViewModels;
using System;

namespace BackendECOTVOS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaterialAssignmentsController : ControllerBase
    {
        private readonly IMaterialAssignmentService _materialAssignmentService;

        public MaterialAssignmentsController(IMaterialAssignmentService materialAssignmentService)
        {
            _materialAssignmentService = materialAssignmentService;
        }

        [HttpPost("AddMaterialAssignment")]
        public async Task<IActionResult> AddMaterialAssignment(MaterialAssignmentViewModel mat)
        {
            try
            {
                int newMatAsignId = await _materialAssignmentService.AddMaterialAssignment(mat);
                string resourceUrl = $"/material/{newMatAsignId}";

                return Created(resourceUrl, null);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to add material assignment (Controller). Exception: " + e.Message);
            }

        }

        [HttpDelete("RemoveMaterialAssignment")]
        public async Task<IActionResult> RemoveMaterialAssignment(MaterialAssignmentViewModel mat)
        {
            try
            {
                await _materialAssignmentService.RemoveMaterialAssignment(mat);

                return Ok();

            }
            catch (Exception e) 
            {
                return BadRequest("Failed to remove material assignment (Controller). Exception: " + e.Message);
            }

        }
    }
}
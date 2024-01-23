using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("GetAllUnassignedMaterials")]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllUnassignedMaterials()
        {
            try
            {
                IEnumerable<MaterialDTO> materials = await _materialService.GetAllUnassignedMaterials();

                return Ok(materials);
            }
           
            catch (Exception e) 
            {
                return BadRequest("Failed to get all unassigned materials (Controller). Exception: " + e.Message);
            }
        }

        [HttpPost("AddMaterial")]
        public async Task<IActionResult> AddMaterial(MaterialViewModel material)
        {
            try
            {
                int addedMaterialId = await _materialService.AddMaterial(material);
                string resourceUrl = $"/material/{addedMaterialId}";

                return Created(resourceUrl, null);
            }

            catch (Exception e)
            {
                return BadRequest("Failed to add material (Controller)." + e.Message);
            }
        }
    }
}

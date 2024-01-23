using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.ViewModels;
using BackendECOTVOS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendECOTVOS.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("AddVehicle")]
        public async Task<IActionResult> AddVehicle(VehicleViewModel vehicle)
        {
            try
            {
                int newVehicleId = await _vehicleService.AddVehicle(vehicle);
                string resourceUrl = $"/vehile/{newVehicleId}";
                return Created(resourceUrl, null);
            }
            catch(Exception e)
            {
                return BadRequest("Failed to add vehicle (controller) " + e.Message);
            }
        }

        [HttpGet("GetAllVehicles")]
        public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetAllVehicles()
        {
            try
            {
                IEnumerable <VehicleDTO> vehicles = await _vehicleService.GetAllVehicles();
                return Ok(vehicles);
            }
            catch (Exception e)
            {
                return BadRequest("Failde to get all vehicles (controller) " + e.Message);
            }
        }

        [HttpGet("GetVehicleById")]
        public async Task<ActionResult<VehicleDTO>> GetVehicleById(int id)
        {
            try
            {
                VehicleDTO vehicle = await _vehicleService.GetVehicleById(id);
                return Ok(vehicle);
            }
            catch(Exception e)
            {
                return BadRequest("Failed to get vehicle by id (controller): " + e.Message);
            }
        }
    }
}

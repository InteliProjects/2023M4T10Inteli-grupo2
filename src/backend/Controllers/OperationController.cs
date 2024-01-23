using Microsoft.AspNetCore.Mvc;
using BackendECOTVOS.Services.Interfaces;
using System.Collections.Generic;
using BackendECOTVOS.Domain.Entities;
using System.Threading.Tasks;
using System;
using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.ViewModels;

namespace BackendECOTVOS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _opService;

        public OperationController(IOperationService opService)
        {
            _opService = opService;
        }

        [HttpGet("GetAllOperations")]
        public async Task<ActionResult<IEnumerable<OperationDTO>>> GetAllOperations()
        {
            try
            {
                IEnumerable<OperationDTO> operations = await _opService.GetAllOperations();

                return Ok(operations);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get operations (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetActiveOperations")]
        public async Task<ActionResult<IEnumerable<Operation>>> GetActiveOperations()
        {
            try
            {
                IEnumerable<OperationDTO> operations = await _opService.GetActiveOperations();
                return Ok(operations);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get active operations (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetLostOperations")]
        public async Task<ActionResult<IEnumerable<OperationDTO>>> GetLostOperations()
        {
            try
            {
                IEnumerable<OperationDTO> operations = await _opService.GetLostOperations();
                return Ok(operations);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get lost operations (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetFinishedOperations")]
        public async Task<ActionResult<IEnumerable<OperationDTO>>> GetFinishedOperations()
        {
            try
            {
                IEnumerable<OperationDTO> operations = await _opService.GetFinishedOperations();
                return Ok(operations);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get finished operations (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetOperation/{id}")]
        public async Task<ActionResult<Operation>> GetOperationById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid operation ID.");
            }

            try
            {
                Operation op = await _opService.GetOperationById(id);
                return Ok(op);
            }
            catch (Exception e) 
            {
                return BadRequest("Failed to get operation by id (Controller). Exception: " + e.Message);
            }
        }

        [HttpPost("AddOperation")]
        public async Task<IActionResult> AddOperation(OperationViewModel op)
        {
            int newOpId = await _opService.AddOperation(op);
            string resourceUrl = $"/operation/{newOpId}";

            return Created(resourceUrl, null);

        }

        [HttpPut("UpdateOperationStatus/{id}")]
        public async Task<IActionResult> UpdateOperationStatus(int id, char status)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid operation ID.");
            }

            try
            {
                await _opService.UpdateOperationStatus(id, status);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("Operation not found (Controller). Exception: " + e.Message);
            }
        }
    }
}
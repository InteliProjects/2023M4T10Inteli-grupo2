using BackendECOTVOS.Domain.DTOs;
using BackendECOTVOS.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BackendECOTVOS.Services;

namespace BackendECOTVOS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorService _operatorsService;

        public OperatorController(IOperatorService operatorsService)
        {
            _operatorsService = operatorsService;
        }

        [HttpPost("AddOperator")]
        public async Task<IActionResult> AddOperator(OperatorViewModel opv)
        {
            try
            {
                int newOpId = await _operatorsService.AddOperator(opv);
                string resourceUrl = $"/operator/{newOpId}";

                return Created(resourceUrl, null);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to add operator (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetAllOperators")]
        public async Task<ActionResult<IEnumerable<OperatorDTO>>> GetAllOperators()
        {
            try
            {
                IEnumerable<OperatorDTO> operators = await _operatorsService.GetAllOperators();

                return Ok(operators);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get all operators (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetOperatorById/{id}")]
        public async Task<ActionResult<OperatorDTO>> GetOperatorById(int id)
        {
            try
            {
                OperatorDTO operatorResult = await _operatorsService.GetOperatorById(id);

                return Ok(operatorResult);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get operator by id (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetOperatorByName/{name}")]
        public async Task<ActionResult<OperatorDTO>> GetOperatorByName(string name)
        {
            try
            {
                OperatorDTO operatorResult = await _operatorsService.GetOperatorByName(name);

                return operatorResult;
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get operator by name (Controller). Exception: " + e.Message);
            }
        }

        [HttpPut("UpdateOperator")]
        public async Task<IActionResult> UpdateOperator(OperatorDTO op)
        {
            try
            {
                await _operatorsService.UpdateOperator(op);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Failed to update operator (Controller). Exception: " + e.Message);
            }
        }

        [HttpDelete("DeleteOperator/{id}")]
        public async Task<IActionResult> DeleteOperator(int id)
        {
            try
            {
                await _operatorsService.DeleteOperator(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Failed to delete operator (Controller). Exception: " + e.Message);
            }
        }
    }
}
using BackendECOTVOS.Domain.Entities;
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
    public class LogisticController : ControllerBase
    {
        private readonly ILogisticService _logisticService;

        public LogisticController(ILogisticService logisticService)
        {
            _logisticService = logisticService;
        }

        [HttpPost("AddLogistic")]
        public async Task<IActionResult> AddLogistic(LogisticViewModel log)
        {
            try
            {
                int newLogisticId = await _logisticService.AddLogistic(log);
                string resourceUrl = $"/logistic/{newLogisticId}";

                return Created(resourceUrl, null);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to add logistic (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetLogisticByOperatorId/{id}")]
        public async Task<IActionResult> GetLogisticByOperatorId(int id)
        {
            try
            {
                Logistic log = await _logisticService.GetLogisticByOperatorId(id);

                return Ok(log);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get logistic by operator id (Controller). Exception: " + e.Message);
            }
        }

        [HttpGet("GetAllLogistics")]
        public async Task<IActionResult> GetAllLogistics()
        {
            try
            {
                IEnumerable<Logistic> logs =  await _logisticService.GetAllLogistics();

                return Ok(logs);
            }
            catch (Exception e)
            {
                return BadRequest("Failed to get all logistics (Controller). Exception: " + e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/operation")]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<OperationController> _logger;
        private readonly IKiranicoClient _kiranicoClient;

        public OperationController(ILogger<OperationController> logger, IKiranicoClient kiranicoClient)
        {
            _logger = logger;
            _kiranicoClient = kiranicoClient;
        }
        
        /// <summary>
        /// Test the availability of service
        /// </summary>
        /// <returns></returns>
        [HttpGet("greet")]
        [ProducesResponseType(typeof(string),200)]
        [ProducesResponseType(typeof(string),404)]
        public string Hello()
        {
            const string response = "Hello";
            return response;
        }
        
        /// <summary>
        /// Get single monster data
        /// </summary>
        /// <br/>
        /// Used to obtain monster data.
        /// <br/>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getMonsterById/{id:int}")]
        [ProducesResponseType(typeof(MonsterDto),200)]
        [ProducesResponseType(typeof(string),404)]
        public async Task<ActionResult<MonsterDto>> GetMonsterById(int id)
        {
            MonsterDto dto = await _kiranicoClient.GetMonster(id);

            if (dto is null) return NotFound();
            
            return dto;
        }
    }
}
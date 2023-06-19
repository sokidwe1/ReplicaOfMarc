using Business.Abstractions;

using Business.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Training.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;

    

        public IClientEngine ClientEngine { get; set; }

        public ClientController(IClientEngine clientEngine, ILogger<ClientController> logger)
        {
            ClientEngine = clientEngine;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientRequestDTO client)
        {
            _logger.LogWarning("Executing the Create action in ClientController.");
            await ClientEngine.CreateClient(client);

            return Ok();
        }

        [HttpPut("/api/clients/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ClientRequestDTO client)
        {
            _logger.LogWarning("Executing the Update action in ClientController.");
            await ClientEngine.UpdateClient(id, client);
            return Ok();
        }



    }
}
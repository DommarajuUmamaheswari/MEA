using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Momentum.External.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class LogicController : ControllerBase
    {
        private readonly ILogger<LogicController> _logger;

        public LogicController(ILogger<LogicController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Implementation pending";
        }

        [HttpPost]
        public string Post()
        {
            return "Implementation pending";
        }

        [HttpDelete]
        public string Delete()
        {
            return "Implementation pending";
        }

        [HttpPut]
        public string Put()
        {
            return "Implementation pending";
        }
    }
}

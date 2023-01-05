using Microsoft.AspNetCore.Mvc;
using Teams.Core.Person;

namespace Teams.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonService _service;

        public PersonController(
            ILogger<PersonController> logger,
            PersonService service) : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public Person Index([FromQuery] int id)
        {
            _logger.LogDebug("Getting person info...");
            return _service.GetById(id);
        }
    }
}

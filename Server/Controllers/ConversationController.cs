using Microsoft.AspNetCore.Mvc;
using Teams.Core.Conversation;

namespace Teams.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : ControllerBase
    {
        private readonly ILogger<ConversationController> _logger;
        private readonly ConversationService _conversation;

        public ConversationController(ILogger<ConversationController> logger, ConversationService conversation)
        {
            _logger = logger;
            _conversation = conversation;
        }

        [HttpPost]
        public void Start(ConversationStartDTO request)
        {
            _conversation.Create(request);
            _logger.LogDebug("Created a new conversation...");
        }

        [HttpGet]
        public Conversation Index([FromQuery] int id)
        {
            _logger.LogDebug("Listing all conversations...");
            return _conversation.Get(id);
        }
    }
}

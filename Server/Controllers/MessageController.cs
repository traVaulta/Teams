using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teams.Core.Message;

namespace Teams.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<ConversationController> _logger;
        private readonly MessageService _message;

        public MessageController(ILogger<ConversationController> logger, MessageService message)
        {
            _logger = logger;
            _message = message;
        }

        [HttpPost]
        public void Send(Message message)
        {
            _message.Send(message);
            _logger.LogDebug("Created a new conversation...");
        }
    }
}

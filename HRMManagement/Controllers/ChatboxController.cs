using HRMManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace HRMManagement.Controllers
{
    [Route("api/[controller]")]
    public class ChatboxController : Controller
    {
        private readonly ChatGptClient _chatGptClient;

        public ChatboxController(ChatGptClient chatGptClient)
        {
            _chatGptClient = chatGptClient;
        }

        public IActionResult Chatbox()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        {
            if (message == null || string.IsNullOrWhiteSpace(message.Message))
                return BadRequest();

            var response = await _chatGptClient.GenerateResponseAsync(message.Message);
            return Ok(response);
        }
    }

    public class ChatMessage
    {
        public string Message { get; set; }
    }
}


using Microsoft.AspNetCore.Mvc;
using NeuralNetworkApi.Models;
using NeuralNetworkApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NeuralNetworkApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Endpoints for the ChatGPT chat model")]
    public class ChatController : ControllerBase
    {
        private readonly IChatGptService _chatGptService;

        public ChatController(IChatGptService chatGptService)
        {
            _chatGptService = chatGptService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCompletionFromPrompt(string prompt)
        {
            try
            {
                var response = await _chatGptService.GetChatResponseAsync(prompt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCompletionFromRequest(ChatRequest request)
        {
            try
            {
                var response = await _chatGptService.GetChatResponseAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

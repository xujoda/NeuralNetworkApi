using Microsoft.AspNetCore.Mvc;
using NeuralNetworkApi.Models;
using NeuralNetworkApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace NeuralNetworkApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Endpoints for the regular completion models")]
    public class CompletionController : ControllerBase
    {
        private readonly IChatGptService _chatGptService;

        public CompletionController(IChatGptService chatGptService)
        {
            _chatGptService = chatGptService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCompletionFromPrompt(string prompt)
        {
            try
            {
                var response = await _chatGptService.GetCompletionResponseAsync(prompt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("FromRequest")]
        public async Task<IActionResult> GetCompletionFromRequest(CompletionRequest request)
        {
            try
            {
                var response = await _chatGptService.GetCompletionResponseAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

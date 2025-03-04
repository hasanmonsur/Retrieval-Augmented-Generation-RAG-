using Microsoft.AspNetCore.Mvc;
using RagApi.Helpers;
using RagApi.Models;
using RagApi.Services;

namespace RagApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RagController : ControllerBase
    {
        private readonly OpenAIService _openAIService;
        private readonly DataRetriever _dataRetriever;
        //http://localhost:5035
        public RagController(DataRetriever dataRetriever, OpenAIService openAIService)
        {
          _openAIService = openAIService;
          _dataRetriever = dataRetriever;
        }

        // Endpoint to fetch and generate response
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateResponse([FromBody] DataCl data)
        {
            // Retrieve relevant data from the system
            string retrievedData = _dataRetriever.RetrieveRelevantData(data.query);

            // Use the retrieved data as context for generating text with OpenAI API
            string prompt = $"Context: {retrievedData}\n\nQuestion: {data.query}\nAnswer:";
            string generatedResponse = await _openAIService.GenerateTextAsync(prompt);

            return Ok(new { Response = generatedResponse });
        }
    }
}

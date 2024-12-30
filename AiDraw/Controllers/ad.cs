using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public AiController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost("GenerateImage")]
        public async Task<IActionResult> GenerateImage([FromBody] AiRequest request)
        {
            // Replace with your OpenAI API Key
            string apiKey = "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";
            string openAiUrl = "https://api.openai.com/v1/images/generations";

            var payload = new
            {
                prompt = request.Prompt,
                n = 1,
                size = "512x512"
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, openAiUrl);
            httpRequest.Headers.Add("Authorization", $"Bearer {apiKey}");
            httpRequest.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new { error = "Failed to generate image." });
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return Ok(JsonConvert.DeserializeObject(responseBody));
        }
    }

    public class AiRequest
    {
        public string Prompt { get; set; }
    }
}


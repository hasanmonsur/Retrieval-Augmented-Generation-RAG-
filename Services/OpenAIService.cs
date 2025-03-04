using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RagApi.Services
{
    public class OpenAIService
    {
        private readonly string _apiKey;

        public OpenAIService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<string> GenerateTextAsync(string prompt)
        {
            var url = "https://api.openai.com/v1/chat/completions"; // OpenAI completions endpoint

            // Construct the request body, using messages with roles (user, assistant)
            var requestData = new
            {
                model = "gpt-3.5-turbo", // or "gpt-3.5-turbo"
                messages = new[]
                {
                    new { role = "user", content = prompt } // The user prompt
                },
                max_tokens = 150,
                temperature = 0.7
            };

            using (var client = new HttpClient())
            {
                // Set Authorization header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

                // Serialize the request data to JSON
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                // Make the API call
                var response = await client.PostAsync(url, content);

                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    dynamic json = JsonConvert.DeserializeObject(jsonResponse);

                    // Extract and return the generated text from the response
                    return json.choices[0].message.content.ToString().Trim();
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }
    }
}

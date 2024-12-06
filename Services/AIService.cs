using AIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AIApp.Services
{
    public class AIService
    {
        // TODO: Replace API key
        string apiKey = "";
        string endpoint = "https://openai-utb.openai.azure.com/";
        string modelName = "gpt-4";
        string imageModelName = "dall-e-3";

        HttpClient client;

        public AIService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(endpoint);
            client.DefaultRequestHeaders.Add("api-key", apiKey);
        }

        public async Task<string> Ask(string prompt)
        {
            AIMessage message = new AIMessage()
            {
                role = "user",
                content = prompt
            };

            AIMessage[] messages = { message };

            AIRequest request = new AIRequest()
            {
                messages = messages
            };

            string chatUrl = $"openai/deployments/{modelName}/chat/completions?api-version=2024-10-21";
            var response = await client.PostAsJsonAsync(chatUrl, request);

            if (response.IsSuccessStatusCode)
            {
                AIResponse aiResponse = await response.Content.ReadFromJsonAsync<AIResponse>();
                return aiResponse.choices.FirstOrDefault()?.message.content;
            }
            else
                return "Error";
        }

        public async Task<string> GenerateImage(string prompt)
        {
            ImageRequest request = new ImageRequest()
            {
                prompt = prompt,
                size = "1024x1024",
                n = 1,
                quality = "hd",
                style = "natural"
            };

            string imageRequestUrl = 
                $"openai/deployments/{imageModelName}/images/generations?api-version=2024-02-01";

            var response = await client.PostAsJsonAsync(imageRequestUrl, request);

            if (response.IsSuccessStatusCode)
            {
                ImageResponse imageResponse =
                    await response.Content.ReadFromJsonAsync<ImageResponse>();

                return imageResponse.data.FirstOrDefault()?.url;
            }
            else
                return string.Empty;
        }
    }
}

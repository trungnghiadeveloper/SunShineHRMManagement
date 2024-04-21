
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HRMManagement.Repositories;
public class ChatGptClient 
{
    private readonly HttpClient _client;

    public ChatGptClient(string apiKey)
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<string> GenerateResponseAsync(string message)
    {
        var requestBody = new { prompt = message, max_tokens = 150 };
        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("https://api.openai.com/v1/engines/davinci-codex/completions", content);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var responseData = JsonSerializer.Deserialize<ChatGptResponse>(responseBody);

        return responseData.choices[0].text.Trim();
    }
}

public class ChatGptResponse
{
    public ChatGptChoice[] choices { get; set; }
}

public class ChatGptChoice
{
    public string text { get; set; }
}

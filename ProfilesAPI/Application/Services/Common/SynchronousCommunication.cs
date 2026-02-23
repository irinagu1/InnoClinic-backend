using System.Net.Http.Json;
using System.Text.Json;

public class SynchronousCommunication
{
    private readonly HttpClient client;
    public SynchronousCommunication()
    {
        client = new HttpClient();
    }

    public async Task<bool> CheckIfEmailIsExistAsync(string email)
    {
        string url = $"https://localhost:4321?email={email}";
        
        HttpResponseMessage response = await client.GetAsync(url);
        
        response.EnsureSuccessStatusCode();
        
        using var stream = response.Content.ReadAsStream();
        
        bool result = JsonSerializer.Deserialize<bool>(stream);
        
        return result;
    }
}
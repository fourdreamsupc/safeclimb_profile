namespace safeclimb_profile.Connection;

public class ConnectionService
{
    private readonly HttpClient _httpClient;
    private const string BaseApiUrl = "https://localhost/endpoint";
    
    public ConnectionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<string> GetApiResponse()
    {
        
        var response = await _httpClient.GetAsync(BaseApiUrl);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        else
        {
            throw new Exception($"Error al llamar al endpoint: {response.StatusCode}");
        }
    }
}
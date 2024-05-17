public class PaginatedLeadResponse
{
    public List<Lead> Items { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public int Total { get; set; }
    public int TotalPages { get; set; }
    public int FirstEntry { get; set; }
    public int LastEntry { get; set; }
}

public class WarmurApiService : IWarmurApiService
{
    private readonly HttpClient _httpClient;

    public WarmurApiService(IConfiguration configuration)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"])
        };
        _httpClient.DefaultRequestHeaders.Add("x-api-key", configuration["ApiSettings:ApiKey"]);
    }


    /// Leads API Calls
    public async Task<PaginatedResponse<Lead>> GetLeadsAsync(int page, int size = 10)
    {
        var response = await _httpClient.GetAsync($"/api/leads?page={page}&size={size}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<PaginatedResponse<Lead>>();
        return content;
    }

    public async Task<Lead> GetLeadAsync(int leadId)
    {
        var response = await _httpClient.GetAsync($"/api/leads/{leadId}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<Lead>();
        return content;
    }


    /// Indicator API Calls
    public async Task<PaginatedResponse<Indicator>> GetLeadIndicatorsAsync(int leadId, int page, int size = 10)
    {
        var response = await _httpClient.GetAsync($"/api/leads/{leadId}/indicators?page={page}&size={size}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<PaginatedResponse<Indicator>>();
        return content;
    }

    public async Task<Indicator> PostLeadIndicatorAsync(int leadId, Indicator indicator)
    {
        var response = await _httpClient.PostAsJsonAsync($"/api/leads/{leadId}/indicators", indicator);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<Indicator>();
        return content;
    }

    public async Task<Indicator> GetLeadIndicatorAsync(int leadId, int indicatorId)
    {
        var response = await _httpClient.GetAsync($"/api/leads/{leadId}/indicators/{indicatorId}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<Indicator>();
        return content;
    }

    public async Task<Indicator> PutLeadIndicatorAsync(int leadId, int indicatorId, IndicatorValue indicatorValue)
    {
        var response = await _httpClient.PutAsJsonAsync($"/api/leads/{leadId}/indicators/{indicatorId}", new { value = indicatorValue } );
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadFromJsonAsync<Indicator>();
        return content;
    }

    public async Task DeleteLeadIndicatorAsync(int leadId, int indicatorId)
    {
        var response = await _httpClient.DeleteAsync($"/api/leads/{leadId}/indicators/{indicatorId}");
    }
}


using Microsoft.AspNetCore.Mvc;

public class LeadsController : Controller
{
    private readonly IWarmurApiService _apiService;

    public LeadsController(IWarmurApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Leads(int page = 1)
    {
        var leads = await _apiService.GetLeadsAsync(page);
        return View(leads);
    }

    public async Task<IActionResult> Lead(int leadId)
    {
        var lead = await _apiService.GetLeadAsync(leadId);
        return View(lead);
    }
}

using Microsoft.AspNetCore.Mvc;

public class IndicatorsController : Controller
{
    private readonly IWarmurApiService _apiService;

    public IndicatorsController(IWarmurApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet]
    public async Task<IActionResult> Indicators(int leadId, int page = 1)
    {
        PaginatedResponse<Indicator> indicators = await _apiService.GetLeadIndicatorsAsync(leadId, page);
        return PartialView("_IndicatorsTab", (indicators, leadId));
    }

    [HttpPost]
    public async Task<IActionResult> PostIndicator(int leadId, string name, int value)
    {
        var indicator = new Indicator()
        {
            Name = name,
            Value = new IndicatorValue()
            {
                Value = value,
                Source = "Provided"
            }
        };
        await _apiService.PostLeadIndicatorAsync(leadId, indicator);
        return RedirectToAction("Lead", "Leads", new { leadId } );
    }

    [HttpPut]
    public async Task<IActionResult> PutIndicator(int leadId, int indicatorId, int value)
    {
        var indicatorValue = new IndicatorValue()
        {
            Value = value,
            Source = "Provided"
        };
        await _apiService.PutLeadIndicatorAsync(leadId, indicatorId, indicatorValue);
        return RedirectToAction("Lead", "Leads", new { leadId });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteIndicator(int leadId, int indicatorId)
    {
        await _apiService.DeleteLeadIndicatorAsync(leadId, indicatorId);
        return RedirectToAction("Lead", "Leads", new { leadId });
    }
}

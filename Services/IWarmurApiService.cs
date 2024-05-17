public interface IWarmurApiService
{
    /// <summary>
    /// Get leads from API
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Task<PaginatedResponse<Lead>> GetLeadsAsync(int page, int size = 10);
    /// <summary>
    /// Get lead from API
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Lead> GetLeadAsync(int id);
    /// <summary>
    /// Get the lead indicators
    /// </summary>
    /// <param name="leadId"></param>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Task<PaginatedResponse<Indicator>> GetLeadIndicatorsAsync(int leadId, int page, int size = 10);
    /// <summary>
    /// Get the indicator
    /// </summary>
    /// <param name="leadId"></param>
    /// <param name="indicatorId"></param>
    /// <returns></returns>
    public Task<Indicator> GetLeadIndicatorAsync(int leadId, int indicatorId);
    /// <summary>
    /// Add a new indicator
    /// </summary>
    /// <param name="leadId"></param>
    /// <param name="indicator"></param>
    /// <returns></returns>
    public Task<Indicator> PostLeadIndicatorAsync(int leadId, Indicator indicator);
    /// <summary>
    /// Update an indicator value
    /// </summary>
    /// <param name="leadId"></param>
    /// <param name="indicatorId"></param>
    /// <param name="indicatorValue"></param>
    /// <returns></returns>
    public Task<Indicator> PutLeadIndicatorAsync(int leadId, int indicatorId, IndicatorValue indicatorValue);
    /// <summary>
    /// Delete indicator
    /// </summary>
    /// <param name="leadId"></param>
    /// <param name="indicatorId"></param>
    /// <returns></returns>
    public Task DeleteLeadIndicatorAsync(int leadId, int indicatorId);
}


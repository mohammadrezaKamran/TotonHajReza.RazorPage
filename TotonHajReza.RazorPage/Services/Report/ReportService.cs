using TotonHajReza.RazorPage.Models.Category;
using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Report;
using TotonHajReza.RazorPage.Services.Report;

public class ReportService : IReportService
{
    private readonly HttpClient _client;
    private const string ModuleName = "Report";

    public ReportService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<ProductReportDto?>> GetAllProductReport()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<ProductReportDto?>>>($"{ModuleName}/AllProduct");
        return result?.Data;
    }

    public async Task<List<ProductSalesDto>> GetBestSellersProduct()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<ProductSalesDto?>>>($"{ModuleName}/BestSellersProduct");
        return result?.Data;
    }

    public async Task<long> GetCountOFProduct()
    {
        var result = await _client.GetFromJsonAsync<long>($"{ModuleName}/CountOFProduct");
        return result;
    }

    public async Task<List<LatestCommentDto>> GetLatestComment()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<LatestCommentDto>>>($"{ModuleName}/LatestComment");
        return result?.Data;
    }

    public async Task<List<MonthlyIncomeReportDto?>> GetMonthlyIncomeReport(int MonthCount)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<MonthlyIncomeReportDto?>>>($"{ModuleName}/{MonthCount}");
        return result?.Data;
    }

    public async Task<long> GetNewOrder()
    {
        var result = await _client.GetFromJsonAsync<long>($"{ModuleName}/NewOrder");
        return result;
    }

    public async Task<List<OutOfStockProductDto>> GetOutOfStockProduct()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<OutOfStockProductDto>>>($"{ModuleName}/OutOfStockProduct");
        return result?.Data;
    }

    public async Task<RecentUsersReportDto?> GetRecentUserReport(int Days)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<RecentUsersReportDto?>>($"{ModuleName}/RecentUsers/{Days}");
        return result?.Data;
    }

    public async Task<long> GetTodaysSales()
    {
        var result = await _client.GetFromJsonAsync<long>($"{ModuleName}/TodaysSales");
        return result;
    }

    public async Task<IncomeReportDto?> GetTotalIncomeReport()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<IncomeReportDto?>>($"{ModuleName}/TotalIncome");
        return result?.Data;
    }
}
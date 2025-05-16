using TotonHajReza.RazorPage.Models.Report;

namespace TotonHajReza.RazorPage.Services.Report
{
    public interface IReportService
    {
        Task<IncomeReportDto?> GetTotalIncomeReport();
        Task<List<MonthlyIncomeReportDto?>> GetMonthlyIncomeReport(int MonthCount);
        Task<long> GetTodaysSales();

        Task<long> GetNewOrder();

        Task<List<ProductReportDto?>> GetAllProductReport();
        Task<List<ProductSalesDto>> GetBestSellersProduct();
        Task<long> GetCountOFProduct();
        Task<List<OutOfStockProductDto>> GetOutOfStockProduct();

        Task<RecentUsersReportDto?> GetRecentUserReport(int Days);
        Task<List<LatestCommentDto>> GetLatestComment();
    }
}

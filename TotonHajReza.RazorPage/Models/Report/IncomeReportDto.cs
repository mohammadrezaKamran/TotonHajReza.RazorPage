using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Products;

namespace TotonHajReza.RazorPage.Models.Report
{
    public class IncomeReportDto
    {
        public decimal TotalIncome { get; set; }
        public int TotalOrders { get; set; }
    }
    public class MonthlyIncomeReportDto
    {
        public string Month { get; set; }
        public decimal TotalIncome { get; set; }
    }

    public class SalesReportDto
    {
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
    }
}





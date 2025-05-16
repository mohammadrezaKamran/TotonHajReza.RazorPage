using TotonHajReza.RazorPage.Models;

public class RecentUsersReportDto
{
    public int Count { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}
public class LatestCommentDto : BaseDto
{
    public long ProductId { get; set; }
    public string Comment { get; set; }
}
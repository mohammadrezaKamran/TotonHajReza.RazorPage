namespace TotonHajReza.RazorPage.Models.Users
{
    public class UserFilterParams : BaseFilterParam
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public long? Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
    }
}

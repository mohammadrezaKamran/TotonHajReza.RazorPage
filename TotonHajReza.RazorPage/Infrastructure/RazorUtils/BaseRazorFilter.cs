
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Models;

namespace TotonHajReza.RazorPage.Infrastructure.RazorUtils;

public class BaseRazorFilter<TFilterParam> : PageModel where TFilterParam : BaseFilterParam
{
    [BindProperty(SupportsGet = true)]
    public TFilterParam FilterParams { get; set; }
}
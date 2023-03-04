using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenAiQuickStartCSharp.Pages;

public class IndexModel : PageModel
{
    public string Name { get; set; }

    public void OnGet()
    {
        Name = "World";
    }
}
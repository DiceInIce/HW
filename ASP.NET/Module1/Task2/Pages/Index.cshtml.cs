using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task2.Pages;

public class IndexModel : PageModel
{
    public string RandomLetter { get; private set; } = string.Empty;

    public void OnGet()
    {
        var random = new Random();
        RandomLetter = ((char)random.Next('A', 'Z' + 1)).ToString();
    }
}

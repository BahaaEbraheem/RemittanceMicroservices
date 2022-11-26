using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EShopOnAbp.CurrencyService.Pages;

public class IndexModel : CurrencyServicePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}

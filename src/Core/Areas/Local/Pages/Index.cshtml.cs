using Domain.Local;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Core.Areas.Local
{
    public class IndexModel : PageModel
    {
        public OrganizationOptions OrgOptions { get; set; }

        public IndexModel(IOptionsMonitor<OrganizationOptions> orgOptionsMonitor)
        {
            OrgOptions = orgOptionsMonitor.CurrentValue;
        }

        public void OnGet()
        {
        }
    }
}

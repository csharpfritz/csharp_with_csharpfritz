using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Areas.Identity.Data;

namespace WebApp1.Pages
{

	public class SecretModel : PageModel {

        public IActionResult OnGet()
        {
            return Page();
        }
		
	}

}
using CRUD_Сlients_API.Models.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Сlients_API.Pages
{

    public class Create : PageModel
    {
        [BindProperty]
        public static ClientInfoViewModel currClient { get; set; } = new ClientInfoViewModel();

        public void OnGet()
        {

        }
        //[IgnoreAntiforgeryToken]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostAddChild(Child child)
        {
            //ClientInfoViewModel test = ViewData["curr"] as ClientInfoViewModel;
            currClient.children.Add(new Child() {name="fsdfsf" });
            return new JsonResult(currClient);
        }
        public async Task<IActionResult> OnPostAsync(ClientInfoViewModel Test)
        {
            return Page();
        }



    }
}

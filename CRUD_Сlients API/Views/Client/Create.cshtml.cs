using CRUD_Сlients_API.Models.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Сlients_API.Views.Client
{
    public class Create : PageModel
    {
        [BindProperty]
        public ClientInfoViewModel currClient { get; set; }
        public Create()
        {
            currClient=new ClientInfoViewModel();
        }

        public void OnGet()
        {

        }
        public void OnPostAddChild(Child child)
        {
            currClient.children.Add(child);
        }



    }
}

using CRUD_Сlients_API.Controllers;
using CRUD_Сlients_API.Models.Client;
using CRUD_Сlients_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace CRUD_Сlients_API.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ClientInfoViewModel currClient { get; set; } = new ClientInfoViewModel();
        private readonly IJsonConverter _converter;
        private readonly ClientController _clientController;
        public CreateModel( IJsonConverter converter, ClientController clientController)
        {
            _converter = converter;
            _clientController = clientController;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public void OnPost()
        {
            _clientController.CreateClient(currClient);
            RedirectToAction("Index", "Client");
            //return Page();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult OnGetAddChild(string name, string surname, string patronymic, DateTime dob)
        {
            List<Child> children = new();
            if (Helpers.SessionExtensions.Contains(HttpContext.Session, "children"))
                children = Helpers.SessionExtensions.Get<List<Child>>(HttpContext.Session, "children", _converter);
            children.Add(new Child()
            {
                id = Guid.NewGuid(),
                name = name,
                surname = surname,
                patronymic = patronymic,
                dob = dob
            });
            Helpers.SessionExtensions.Set(HttpContext.Session, "children", children, _converter);

            return Partial("ChildrenPartial", children);//ChildrenPartial();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult OnGetRemoveChild(Guid id)
        {
            List<Child> children = new();
            if (Helpers.SessionExtensions.Contains(HttpContext.Session, "children"))
                children = Helpers.SessionExtensions.Get<List<Child>>(HttpContext.Session, "children", _converter);
            var item = children.First(x => x.id == id);
            children.Remove(item);
            Helpers.SessionExtensions.Set(HttpContext.Session, "children", children, _converter);
            return Partial("ChildrenPartial", children);//ChildrenPartial();
        }
    }
}

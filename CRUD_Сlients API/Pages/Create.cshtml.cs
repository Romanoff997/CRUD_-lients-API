using CRUD_Сlients_API.Models.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using CRUD_Сlients_API.Services;
using System.Net.Http.Headers;

namespace CRUD_Сlients_API.Pages
{

    public class Create : PageModel
    {
        //[BindProperty(SupportsGet = true)]
        public  ClientInfoViewModel currClient { get; set; } = new ClientInfoViewModel();
        private List<Child> children = new()
        { 
            new Child()
            { 
                name= "name",
                surname = "dfsd"
            },
            new Child()
            { 
                name= "name2",
                surname = "dfsd"
            }
        };
        private  IJsonConverter _converter;
        
        public Create(IJsonConverter converter)
        {
            _converter = converter;
                   
        }
        public IActionResult OnGet()
        {
            currClient.children = children;
            return Page();
        }

        public IActionResult OnGetPatrial() 
        {
            var children = CRUD_Сlients_API.Helpers.SessionExtensions.Get<List<Child>>(HttpContext.Session, "children", _converter);
            return Patrial("ChildrenPartial", children);
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult OnGetAddChild( string name, string surname, string patronymic, DateTime dob)
        {
            children.Add(new Child()
            {
                id = new Guid(),
                name = name,
                surname = surname,
                patronymic = patronymic,
                dob = dob
            }) ;
            Helpers.SessionExtensions.Set(HttpContext.Session, "children", children, _converter);
            return ChildrenPartial();
        }

        [HttpPost]
        public  IActionResult OnPost(ClientInfoViewModel Test)
        {
            return new JsonResult("dfsd");
        }



    }
}

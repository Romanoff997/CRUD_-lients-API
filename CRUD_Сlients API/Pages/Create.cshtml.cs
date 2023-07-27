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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using CRUD_Сlients_API.Controllers;

namespace CRUD_Сlients_API.Pages
{
   // [BindProperties(SupportsGet = true)]
    public class Create : PageModel
    {
 
        [BindProperty(SupportsGet = true)]
        public  ClientInfoViewModel currClient { get; set; } = new ClientInfoViewModel();
        private List<Child> children { get; set; } = new();
        private readonly ClientController _clientController;
        //};
        private  IJsonConverter _converter;
        
        public Create(ClientController clientController,IJsonConverter converter)
        {
            _converter = converter;
            _clientController = clientController;
                   
        }
        public void OnGet()
        {
            //currClient.children = children;
            // return Page();
        }
        [ValidateAntiForgeryToken]
        public IActionResult OnPost(ClientInfoViewModel client)
        {
            return Page();// _clientController.CreateClient(currClient);
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult OnGetAddChild( string name, string surname, string patronymic, DateTime dob)
        {

            if(Helpers.SessionExtensions.Contains(HttpContext.Session, "children"))
                children = Helpers.SessionExtensions.Get<List<Child>>(HttpContext.Session, "children", _converter);
            children.Add(new Child()
            {
                id = Guid.NewGuid(),
                name = name,
                surname = surname,
                patronymic = patronymic,
                dob = dob
            }) ;
            Helpers.SessionExtensions.Set(HttpContext.Session, "children", children, _converter);
            return Partial("ChildrenPartial", children);//ChildrenPartial();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult OnGetRemoveChild(Guid id)
        {
            if(Helpers.SessionExtensions.Contains(HttpContext.Session, "children"))
                children = Helpers.SessionExtensions.Get<List<Child>>(HttpContext.Session, "children", _converter);
            var item = children.First(x => x.id == id);
            children.Remove(item);
            Helpers.SessionExtensions.Set(HttpContext.Session, "children", children, _converter);
            return Partial("ChildrenPartial", children);//ChildrenPartial();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public  void OnGetTest()
        {
            var df = currClient;
            //var d2 = Request.Form
            //return new JsonResult(currClient);
        }



    }
}

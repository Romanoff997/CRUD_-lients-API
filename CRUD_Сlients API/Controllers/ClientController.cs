
using CRUD_Сlients_API.Services;
using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.Mvc;
using CRUD_Сlients_API.Models.Client;
using System.Text;
using System;
using System.Collections.Generic;

namespace CRUD_Сlients_API.Controllers
{
    public class ClientController: Controller
    {

        private readonly ClientApiService servcie;
         //static private List<ClientInfoViewModel> _client = new List<ClientInfoViewModel>();
         static private ClientRequestViewModel requestGetClients = new ClientRequestViewModel();
        static private ClientInfoViewModel currClient = new ClientInfoViewModel();
        public ClientController()
        {
            servcie = new ClientApiService((object df, ErrorClientResponseModel fdf) => { }, new JsonNewtonConverter());
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", requestGetClients);
        }


        [HttpPost]
        public async Task<IActionResult> GetClients(ClientRequestViewModel form)
        {
            await servcie.GetClinets((Response<ClientResponseModel> result) =>
            {
                requestGetClients = new ClientRequestViewModel
                {
                    request = form.request,
                    data = result.response.data.ToList()
                };
            }, form.request);
            return Index();
        }

        [HttpGet]
        //public IActionResult CreateClient()
        //{
        //    return View("Create");
        //}
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientInfoViewModel client)
        {
           await servcie.CreateClient(() => 
            { 
            
            
            }, client);

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> GetClinet(Guid id)
        {
            ClientInfoViewModel client = new ClientInfoViewModel();
            await servcie.GetClinet((ClientInfoViewModel _client) => 
            {
                currClient = _client;
            }, id);
            return View("Show", currClient);
        }

        [HttpPost]
        public IActionResult Edit(ClientInfoViewModel _currClient)
        {
            return View("Edit", currClient);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateClinet(Guid id)
        {
            servcie.UpdateClinet((string result) =>
            {

            }, 
            new Guid("3fa85f64-5717-4562-b3fc-2c963f66af23"),
            new ClientInfoViewModel()
            {
                id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66af23"),
                name = "тест",
                surname = "family",
                patronymic = " test",
                dob = new DateTime(),
               // children = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" },
                //passport = new PassportModel(),
                //livingAddress = new LivingAddressModel(),
                //regAddress = new RegAddressModel(),
               // jobs = new string[] { "job1", "job2" }

            });
            return Redirect("/");

        }

        [HttpGet]
        public async Task<IActionResult> DeleteClinet(Guid id)
        {
            servcie.DeleteClinet(() => 
            { 
            
            },id);
            return Redirect("/");
        }
        




    }
}

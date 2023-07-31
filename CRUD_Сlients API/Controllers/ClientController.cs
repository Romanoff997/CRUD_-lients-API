
using CRUD_Сlients_API.Services;
using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.Mvc;
using CRUD_Сlients_API.Models.Client;
using System.Text;
using System;
using System.Collections.Generic;

namespace CRUD_Сlients_API.Controllers
{
    public class ClientController : Controller
    {

        private readonly ClientApiService servcie;
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
        public IActionResult CreateClient()
        {
            return RedirectToPage("/Create");
        }
        [HttpPost]
        public IActionResult AddChild(Child chil)
        {
            //children.Add(new Child() { 
            //dob=client.dob,
            //surname=client.surname,
            //patronymic=client.patronymic,   
            //id=new Guid()
            //});
            //currClient.children.Add(new Child()
            //{
            //    dob = chil.dob,
            //    surname = chil.surname,
            //    patronymic = chil.patronymic,
            //    id = new Guid()
            //});e
            return View("Create", currClient);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientInfoViewModel client)
        {
            currClient = client;
            //await servcie.CreateClient(() =>
            // {


            // }, currClient);

            return Index();//RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult Edit()
        {
            return View("Edit", currClient);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClient(ClientInfoViewModel client)
        {
            await servcie.UpdateClinet(() =>
            {

            }, client);
            
            return RedirectToAction("IndexRefresh");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await servcie.DeleteClinet(() => 
            { 
            
            },id);
            return RedirectToAction("IndexRefresh");
        }

        [HttpGet]
        public async Task<IActionResult> IndexRefresh()
        {
            await servcie.GetClinets((Response<ClientResponseModel> result) =>
            {
                requestGetClients = new ClientRequestViewModel
                {
                    request = requestGetClients.request,
                    data = result.response.data.ToList()
                };
            }, requestGetClients.request);
            return Index();
        }
        




    }
}

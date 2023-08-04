
using CRUD_Сlients_API.Services;
using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.Mvc;
using CRUD_Сlients_API.Models.Client;
using System.Text;
using System;
using System.Collections.Generic;
using CRUD_Сlients_API.Models.Pager;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CRUD_Сlients_API.Controllers
{
    public class ClientController : Controller
    {

        private readonly ClientApiService _servcie;
        private static ClientRequestViewModel requestGetClients = new ClientRequestViewModel();
        private static ClientInfoViewModel currClient = new ClientInfoViewModel();
        public ClientController(ClientApiService service)
        {
            _servcie = service;
            _servcie.ErrorHandler += ServerErrorException;
        }

        [HttpGet]
        public IActionResult Index(int pg=1)
        {
            if (requestGetClients.data.Count>0)
            {
                const int pageSize = 5;
                if (pg < 1)
                    pg = 1;
                int recsCount = requestGetClients.data.Count;
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = requestGetClients.data.Skip(recSkip).Take(pager.PageSize).ToList();
                ViewBag.Pager = pager;
                requestGetClients.dataPager = data;

            }
            return View("Index", requestGetClients);
        }


        [HttpPost]
        public async Task<IActionResult> GetClients(ClientRequestViewModel form)
        {

            await _servcie.GetClinets((Response<ClientResponseModel> result) =>
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
        public async Task<IActionResult> CreateClient(ClientInfoViewModel client)
        {
            await _servcie.CreateClient(() =>
            {

            }, client);

            return Index();
        }

        [HttpGet]
        public async Task<IActionResult> GetClinet(Guid id)
        {
            ClientInfoViewModel client = new ClientInfoViewModel();
            await _servcie.GetClinet((ClientInfoViewModel _client) =>
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
            await _servcie.UpdateClinet(() =>
            {

            }, client);
            
            return RedirectToAction("IndexRefresh");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _servcie.DeleteClinet(() => 
            { 
            
            },id);
            return RedirectToAction("IndexRefresh");
        }

        [HttpGet]
        public async Task<IActionResult> IndexRefresh()
        {
            await _servcie.GetClinets((Response<ClientResponseModel> result) =>
            {
                requestGetClients = new ClientRequestViewModel
                {
                    request = requestGetClients.request,
                    data = result.response.data.ToList()
                };
            }, requestGetClients.request);
            return Index();
        }

        public void ServerErrorException(object obj, string message)
        {
            ViewBag.success = false;
            ViewBag.errorMessage = message != null? message: "Ошибка сервера";
        }
        
    }
}

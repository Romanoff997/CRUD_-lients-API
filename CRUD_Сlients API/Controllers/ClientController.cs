﻿
using CRUD_Сlients_API.Services;
using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.Mvc;
using CRUD_Сlients_API.Models.Client;
using System.Text;
using System;

namespace CRUD_Сlients_API.Controllers
{
    public class ClientController: Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly DataManager _dataManager;
        //private readonly IMapingService _mapper;
        //private readonly IShortUrlService _shorter;
        //private readonly IJsonConverter converter;
        private readonly ClientApiService servcie = new ClientApiService((object df, ErrorClientResponseModel fdf) => { }, new JsonNewtonConverter() );
        private IEnumerable<ClientInfoViewModel> clients;
        public ClientController()
        {
            //_userManager = userManager;
            //_dataManager = dataManager;
            //_mapper = mapper;
            //_shorter = new ShortUrlServiceNative();
        }

        public IActionResult Index()
        {
            return View(clients);
        }
        //public IActionResult Index(IEnumerable<ClientInfoViewModel> _clients)
        //{
        //    return View(_clients);
        //}
        [HttpPost]
        public IActionResult GetClients(object dfdf)
        {
            servcie.GetClinets((Response<ClientResponseModel> result) => 
            {
                clients = result.response.data.ToArray();   //Enum.GetValues(typeof(ClientInfoViewModel)).Cast<ClientInfoViewModel>().
                                                            //(ClientInfoViewModel)Enum.GetValues(typeof(result.response.data));
                Index();

            }, new ClientRequestModel() );
            return Index();
        }

        [HttpGet]
        public  Task CreateClient()
        {
            servcie.CreateClient(() => 
            { 
            
            
            }, new ClientInfoModel() {
                id= new Guid("3fa85f64-5717-4562-b3fc-2c963f66af23"),
                name = "тест",
                surname = "family",
                patronymic = " test",
                dob = new DateTime(),
                children = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" }, 
                passport =new PassportModel(),
                //livingAddress = new LivingAddressModel(),
                //regAddress = new RegAddressModel(),
                jobs = new string[] { "job1", "job2" }

            } );
            return Task.CompletedTask;
        }

        [HttpGet]
        public async Task GetClinet()
        {
            servcie.GetClinet((ClientInfoModel client) => 
            { 
             
            }, new Guid("3fa85f64-5717-4562-b3fc-2c963f66af23"));

        }
        [HttpGet]
        public async Task UpdateClinet()
        {
            servcie.UpdateClinet((string result) =>
            {

            }, 
            new Guid("3fa85f64-5717-4562-b3fc-2c963f66af23"),
            new ClientInfoModel()
            {
                id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66af23"),
                name = "тест",
                surname = "family",
                patronymic = " test",
                dob = new DateTime(),
                children = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" },
                passport = new PassportModel(),
                //livingAddress = new LivingAddressModel(),
                //regAddress = new RegAddressModel(),
                jobs = new string[] { "job1", "job2" }

            });

        }
        [HttpGet]
        public async Task DeleteClinet()
        {
            servcie.DeleteClinet(() => 
            { 
            
            }, new Guid());

        }




    }
}

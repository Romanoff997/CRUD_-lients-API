
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
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly DataManager _dataManager;
        //private readonly IMapingService _mapper;
        //private readonly IShortUrlService _shorter;
        //private readonly IJsonConverter converter;
        private readonly ClientApiService servcie = new ClientApiService((object df, ErrorClientResponseModel fdf) => { }, new JsonNewtonConverter() );
       // public IEnumerable<ClientInfoViewModel> clients;
        public ClientController()
        {
            //_userManager = userManager;
            //_dataManager = dataManager;
            //_mapper = mapper;
            //_shorter = new ShortUrlServiceNative();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new List <ClientInfoViewModel>());
        }

        [HttpPost]
        public IActionResult Index(IEnumerable<ClientInfoViewModel> _clients)
        {
            return View(_clients);
        }

        [HttpPost]
        public async Task<IActionResult> GetClients(IFormCollection form)
        {
            ClientRequestModel request = new ClientRequestModel()
            { 
                limit= int.Parse(form["limit"]),
                page= int.Parse( form["page"]),
                search = form["search"],
                sortDir = form["sortDir"],
                sortBy = form["sortBy"]

            };
            await servcie.GetClinets((Response<ClientResponseModel> result) => 
            {
                View("Index", result.response.data.ToArray());
            }, request);
            return View("Index");
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
        public async Task<IActionResult> GetClinet(Guid id)
        {
            servcie.GetClinet((ClientInfoModel client) => 
            {
                View("Edit", client);
            }, id);
            return View("Index");

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

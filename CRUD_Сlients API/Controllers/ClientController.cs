
using CRUD_Сlients_API.Services;
using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.Mvc;
using CRUD_Сlients_API.Models.Client;

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
        public ClientController()
        {
            //_userManager = userManager;
            //_dataManager = dataManager;
            //_mapper = mapper;
            //_shorter = new ShortUrlServiceNative();
        }


        [HttpGet]
        public  Task GetClients()
        {
            servcie.GetClinets((Response<ClientResponseModel> result) => 
            { 
            
            
            }, new ClientRequestModel() );
            return Task.CompletedTask;
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
                //passport =new PassportModel() {number="fdf", createdAt="dgdf", dateIssued  },
                //livingAddress = new LivingAddressModel(),
                //regAddress = new RegAddressModel(),
                jobs = new string[] { "job1", "job2" }

} );
            return Task.CompletedTask;
        }
   

        

    }
}

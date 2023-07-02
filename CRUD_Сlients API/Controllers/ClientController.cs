using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.CompilerServices;

namespace CRUD_Сlients_API.Controllers
{
    public class ClientController: Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly DataManager _dataManager;
        //private readonly IMapingService _mapper;
        //private readonly IShortUrlService _shorter;
       private readonly IJsonConverter converter;
        public ClientController()
        {
            //_userManager = userManager;
            //_dataManager = dataManager;
            //_mapper = mapper;
            //_shorter = new ShortUrlServiceNative();
        }


        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(
                @"https://localhost:3000/clients", );
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            //return response.Headers.Location;
            //return response.Headers.Location;
            //var userId = Guid.Parse(_userManager.GetUserId(User));
            //IEnumerable<LinkModel> Links = await _dataManager.LinkRepository.GetLinksAsync(userId);
            //IQueryable<LinkViewModel> LinksView = _mapper.GetLinkViews(Links.AsQueryable());//_mapper.Map<LinkViewModel>(Links); 
            //List<LinkViewModel> mass = LinksView.ToList();
            return View(LinksView);

        }
        [HttpPost]
        public IActionResult Index(IQueryable<LinkViewModel> LinksView)
        {
            return View(LinksView);
        }
        [HttpPost]
        public async Task<IActionResult> AddLink (IFormCollection form)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));
            string longurl = form["message"];
             string result = "";
            await _shorter.GetShortUrl( (url) =>
            {
                 _dataManager.LinkRepository.AddLinkAsync(userId, longurl, url);
                 //RedirectToAction("Index");
            }, longurl);
            //var aaf = CreateDynamicLink(df);
            //_dataManager.LinkRepository.AddLink(userId, link.Url, link.MinUrl);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> UpTiсket (IFormCollection form)
        {
            Guid id = Guid.Parse(form["IdLink"]);
            var userId = Guid.Parse(_userManager.GetUserId(User));
            if(id!=null)
                await _dataManager.LinkRepository.UpTicketAsync(id);

            return RedirectToAction("Index");

        }

    }
}

using CRUD_Сlients_API.Models.Client;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Сlients_API.Models
{
    public class ClientRequestViewModel
    {
        public List<ClientInfoViewModel>? data { get; set; } = new List<ClientInfoViewModel>();   
        public List<ClientInfoViewModel>? dataPager { get; set; } = new List<ClientInfoViewModel>();
        public ClientRequestModel? request { get; set; } = new ClientRequestModel();
        public SelectList sortDirList { get; } = new SelectList(new List<string>() {"asc", "desc" }); 
       

    }
    public class ClientRequestModel
    {
        [Required(ErrorMessage = "sortBy is required")]
        [Display (Name = "Сортировать по полю")]
        public string sortBy { get; set; } = "";
        [Required(ErrorMessage = "sortDir is required")]
        [Display(Name = "По возростанию/убвыанию (asc/desc)")]
        public string sortDir { get; set; }
        [Required(ErrorMessage = "limit is required")]
        [Display(Name = "Выбрать элементов")]
        public int limit { get; set; }

        [Required(ErrorMessage = "page is required")]
        [Display(Name = "Страница")]
        public int page { get; set; }
        public string? search { get; set; } = "";

    }

}

using CRUD_Сlients_API.Models.Client;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Сlients_API.Models
{
    public class ClientRequestViewModel
    {
        public List<ClientInfoViewModel>? data { get; set; } = new List<ClientInfoViewModel>();   
        public List<ClientInfoViewModel>? dataPager { get; set; } = new List<ClientInfoViewModel>();
        public ClientRequestModel? request { get; set; } = new ClientRequestModel();
    }
    public class ClientRequestModel
    {

        public string? sortBy { get; set; } = "";
        public string? sortDir { get; set; } = "";
        public int? limit { get; set; }
        public int? page { get; set; }
        public string? search { get; set; } = "";

    }
}

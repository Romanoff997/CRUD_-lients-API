using CRUD_Сlients_API.Models.Client;
using System.Numerics;

namespace CRUD_Сlients_API.Models.Pager
{
    public class IndexViewModel
    {
        public IEnumerable<ClientInfoViewModel> Clients { get; set; }
        public Pager PageInfo { get; set; }
    }
}

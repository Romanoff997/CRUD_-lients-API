using System.ComponentModel.DataAnnotations;

namespace CRUD_Сlients_API.Models
{
    public class ClientResponseModel<T>
    {

        public int limit { get; set; }
        public int page { get; set; }
        public int total { get; set; }
        public T data { get; set; }
    }
}

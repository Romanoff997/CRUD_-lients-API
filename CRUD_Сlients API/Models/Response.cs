namespace CRUD_Сlients_API.Models
{
    public class Response<T>
    {
        public int code { get; set; }
        public T response { get; set; }
    }
}

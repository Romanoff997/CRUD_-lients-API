namespace CRUD_Сlients_API.Models
{
    public class ErrorClientResponseModel
    {
        public int status { get; set; }
        public string code { get; set; }
        public List<ExceptionClientResponse> exception { get; set; } = new List<ExceptionClientResponse>();


    }
}

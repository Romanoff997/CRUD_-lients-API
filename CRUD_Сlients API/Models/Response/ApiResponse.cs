namespace CRUD_Сlients_API.Models.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; }
        public string Error { get; }
        public bool HasError => !string.IsNullOrEmpty(Error);

        public ApiResponse(T data)
        {
            Data = data;
        }

        public ApiResponse(string error)
        {
            Error = error;
        }
    }
}

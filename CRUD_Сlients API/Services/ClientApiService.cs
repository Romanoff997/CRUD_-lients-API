
using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using CRUD_Сlients_API.Models.Client;

namespace CRUD_Сlients_API.Services
{
    public class ClientApiService
    {
        private const string url = "https://localhost:7113/api/";
        private readonly EventHandler<ErrorClientResponseModel> ErrorHandler;
        private readonly IJsonConverter _converter;
        public ClientApiService(EventHandler<ErrorClientResponseModel> errorHandler, IJsonConverter converter)
        {
            ErrorHandler += errorHandler;
            _converter = converter;
        }
        public async Task GetClinets(Action<Response<ClientResponseModel>> GetClinet, ClientRequestModel clientQuery)
        {
            using (HttpClient client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                    {
                        //{ "sortBy", "createdAt" },
                        //{ "sortDir",  "asc"},
                        //{ "limit", "10" },
                        //{ "page",  "0" },
                        //{ "search",  "" }
                        { "sortBy", clientQuery.sortBy },
                        { "sortDir", clientQuery.sortDir},
                        { "limit", clientQuery.limit.ToString() },
                        { "page",  clientQuery.page.ToString() },
                        { "search",  clientQuery.search },
                    };

                string queryString = QueryHelpers.AddQueryString("", parameters);

                string urlWithParameters = $"{url}clients{queryString}/";

                HttpResponseMessage response = await client.GetAsync(urlWithParameters);
                string responseBody;

                if (response.IsSuccessStatusCode)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    Response<ClientResponseModel> result = new Response<ClientResponseModel>()
                    {
                        code = 200
                    };
                    result.response = _converter.ReadJson<ClientResponseModel>(responseBody);
                    GetClinet.Invoke(result);
                }
                else
                {


                }
            }

        }
        public async Task CreateClient(Action CreateClinet, ClientInfoViewModel currClient)
        {
            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage(HttpMethod.Post, $"{url}clients")
                {
                    Content = new StringContent(_converter.WriteJson(currClient), Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    CreateClinet?.Invoke();

                }
                else
                {
                    
                }
                
            }
        }
        public async Task GetClinet(Action<ClientInfoViewModel> ShowClinet, Guid clientId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string urlWithParameters = $"{url}clients/{clientId}/";


                    HttpResponseMessage response = await client.GetAsync(urlWithParameters);
                    string responseBody;

                    if (response.IsSuccessStatusCode && response.Content != null)
                    {
                        responseBody = await response.Content.ReadAsStringAsync();
                        ShowClinet?.Invoke(_converter.ReadJson<ClientInfoViewModel>(responseBody));
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex) 
            { 
            }
        }
        public async Task UpdateClinet(Action<string> UpdateClinet, Guid clientId, ClientInfoViewModel currClient)
        {
            using (HttpClient client = new HttpClient())
            {
                string urlWithParameters = $"{url}/clients/?{clientId}/";

                HttpContent content = new StringContent(_converter.WriteJson<ClientInfoViewModel>(currClient), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PatchAsync(urlWithParameters, content);
                string responseBody;
                
                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    //ShowClinet?.Invoke(_converter.ReadJson<ClientInfoModel>(responseBody));
                }
                else
                {

                }
            }
        }
        public async Task DeleteClinet(Action DeleteClinet, Guid clientId)
        {

            using (HttpClient client = new HttpClient())
            {
                string urlWithParameters = $"{url}/clients/?{clientId}";

                HttpResponseMessage response = await client.DeleteAsync(urlWithParameters);

                string responseBody;

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    DeleteClinet?.Invoke();
                }
                else
                {

                }
            }
        }


    }
}

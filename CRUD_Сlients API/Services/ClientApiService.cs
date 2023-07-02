
using CRUD_Сlients_API.Models;
using Microsoft.AspNetCore.WebUtilities;
using CRUD_Сlients_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Components;

namespace CRUD_Сlients_API.Services
{
    public class ClientApiService
    {
        private const string url = "https://localhost:3000";
        private readonly Action <ClientErrorModel> ErrorHandler;
        private readonly IJsonConverter _converter;
        public ClientApiService(EventCallback<ClientErrorModel> errorHandler, IJsonConverter converter)
        {
            ErrorHandler = errorHandler;
            _converter = converter;
        }
        public async Task GetClinet(Action<string> GetClinet, ClientRequestModel clientQuery)
        {
            using (HttpClient client = new HttpClient())
            {

                // Параметры запроса
                var parameters = new Dictionary<string, string>
                    {
                        { "sortBy", clientQuery.sortBy },
                        { "sortDir",  clientQuery.sortDir },
                        { "limit", clientQuery.limit.ToString() },
                        { "page",  clientQuery.page.ToString() },
                        { "search",  clientQuery.search },
                    };

                // Создание строки запроса с параметрами
                string queryString = QueryHelpers.AddQueryString("", parameters);

                // Создание полного URL-адреса с параметрами
                string urlWithParameters = $"{url}/clients/?{queryString}/";

                // Выполнение GET-запроса
                HttpResponseMessage response = await client.GetAsync(urlWithParameters);
                string responseBody;
                // Обработка ответа
                if (response.IsSuccessStatusCode)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(responseBody);
                }
                else
                {
                   // Console.WriteLine($"Ошибка при выполнении запроса. Код состояния: {response.StatusCode}");
                }
                await GetClinet?.Invoke(responseBody);
            }

        }       
        public async Task CreateClinet(Action<ClientErrorModel> CreateClinet, ClientErrorModel clientQuery)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    $"{url}/clients/", clientQuery);
                response.EnsureSuccessStatusCode();

                // Обработка ответа
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    
                }
                else
                {
                    
                }
                GetClinet.Invoke(response.Content.ToString());
            }
        }
        public async Task ShowClinet(Action<ClientInfoModel> ShowClinet, int clientId)
        {
            using (HttpClient client = new HttpClient())
            {

                // Создание полного URL-адреса с параметрами
                string urlWithParameters = $"{url}/clients/?{clientId}/";

                
                HttpResponseMessage response = await client.GetAsync(urlWithParameters);
                string responseBody;

                if (response.IsSuccessStatusCode && response.Content!=null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    ShowClinet?.Invoke(_converter.ReadJson <ClientInfoModel>(value: responseBody));
                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    ErrorHandler.Invoke(_converter.ReadJson<ClientErrorModel>(value: responseBody));
                }
                
            }
        }
        public async Task UpdateClinet(Action<string> UpdateClinet, int clientId)
        {
           
        
            using (HttpClient client = new HttpClient())
            {

                string urlWithParameters = $"{url}/clients/?{clientId}/";

                //HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), urlWithParameters);

                //try
                //{
                //    HttpResponseMessage response = await client.PatchAsync(urlWithParameters);
                //}
                //catch (HttpRequestException ex)
                //{
                //    // Failed
                //}

                HttpResponseMessage response = await client.PatchAsync(urlWithParameters);
                string responseBody;

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    ShowClinet?.Invoke(_converter.ReadJson<ClientInfoModel>(value: responseBody));
                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    ErrorHandler?.Invoke(_converter.ReadJson<ClientErrorModel>(responseBody));
                }
            }
        }
        public async Task DeleteClinet(Action DeleteClinet, int clientId)
        {

            using (HttpClient client = new HttpClient())
            {
                string urlWithParameters = $"{url}/clients/?{clientId}";

                //HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("DELETE"), urlWithParameters);

                HttpResponseMessage response = await client.DeleteAsync(urlWithParameters);

                string responseBody;

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    DeleteClinet?.Invoke();
                }
                else
                {
                   // responseBody = await response.Content.ReadAsStringAsync();
                   // ErrorHandler?.Invoke(_converter.ReadJson<ClientErrorModel>(responseBody));
                }
            }
        }


    }
}

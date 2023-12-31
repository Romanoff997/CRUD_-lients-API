﻿
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
using Newtonsoft.Json;

namespace CRUD_Сlients_API.Services
{
    public class ClientApiService
    {
        private const string url = "https://localhost:7113/api/";
        public event EventHandler<string> ErrorHandler;
        private readonly IJsonConverter _converter;
        public ClientApiService(IJsonConverter converter)
        {
            _converter = converter;
        }
        public async Task GetClinets(Action<Response<ClientResponseModel>> GetClinet, ClientRequestModel clientQuery)
        {
            using (HttpClient client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                    {
                        { "sortBy", clientQuery.sortBy },
                        { "sortDir", clientQuery.sortDir.ToString()},
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
                    responseBody = await response.Content.ReadAsStringAsync();
                    ErrorHandler?.Invoke(this, responseBody);

                }
            }

        }
        public async Task CreateClient(Action CreateClinet, ClientInfoViewModel clientInfo)
        {
            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage(HttpMethod.Post, $"{url}clients")
                {
                    Content = new StringContent(_converter.WriteJson(clientInfo), Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);
                string responseBody;

                if (response.IsSuccessStatusCode)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    CreateClinet?.Invoke();

                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    ErrorHandler?.Invoke(this, responseBody);
                }
                
            }
        }
        public async Task GetClinet(Action<ClientInfoViewModel> ShowClinet, Guid clientId)
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
                    responseBody = await response.Content.ReadAsStringAsync();
                    ErrorHandler?.Invoke(this, responseBody);
                }
            }
            
        }
        public async Task UpdateClinet(Action UpdateClinet, ClientInfoViewModel clientInfo)
        {
            using (HttpClient client = new HttpClient())
            {

                string urlWithParameters = $"{url}clients/{clientInfo.id}/";

                HttpContent content = new StringContent(_converter.WriteJson(clientInfo), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(urlWithParameters, content);
                string responseBody;

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    UpdateClinet?.Invoke();
                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    ErrorHandler?.Invoke(this, responseBody);
                }
            }
        }
        public async Task DeleteClinet(Action DeleteClinet, Guid clientId)
        {

            using (HttpClient client = new HttpClient())
            {
                string urlWithParameters = $"{url}clients/{clientId}/";

                HttpResponseMessage response = await client.DeleteAsync(urlWithParameters);

                string responseBody;

                if (response.IsSuccessStatusCode && response.Content != null)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    DeleteClinet?.Invoke();
                }
                else
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    ErrorHandler?.Invoke(this, responseBody);
                }
            }
        }


    }
}

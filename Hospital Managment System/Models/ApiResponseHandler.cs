using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text.Json.Serialization;

namespace Hospital_Managment_System.Models
{
    public class ApiResponseHandler<T> : IApi<T>
    {
        private string url = "http://localhost:5000";
        HttpClient client = new HttpClient();
        public ApiResponseHandler()
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<T> Delete(string api, int i)
        {
            HttpResponseMessage Del = await client.DeleteAsync(api);
            return await Del.Content.ReadAsAsync<T>();
        }

        public async Task<List<T>> GetAll(string Api)
        {

            HttpResponseMessage Res = await client.GetAsync(Api);
            List<T>? list = new List<T>();
            if (Res.IsSuccessStatusCode)
            {
                var EmpResponcse = Res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<T>>(EmpResponcse);
            }

            return list;
        }

        public async Task<T> GetById(string Api , int id)
        {
            List<T> response = new List<T>();
            HttpResponseMessage Res = await client.GetAsync(Api);
            if (Res.IsSuccessStatusCode)
            {
                var result = await Res.Content.ReadAsAsync<T>();
                return result;
            }

            return response[0];
        }

        //put
        public async Task<T> Update(string Api, T entity)
        {
            HttpResponseMessage Res = await client.PutAsJsonAsync(Api, entity);

            Res.EnsureSuccessStatusCode();
            entity = await Res.Content.ReadAsAsync<T>();
            return entity;
        }

        //post
        public async Task<T> Create(string Api, T entity)
        {
            HttpResponseMessage Res = await client.PostAsJsonAsync(Api, entity);

            Res.EnsureSuccessStatusCode();
            entity = await Res.Content.ReadAsAsync<T>();
            return entity;
        }
    }
}

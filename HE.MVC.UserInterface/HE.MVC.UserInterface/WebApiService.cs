using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using Thinktecture.IdentityModel.Client;

namespace HE.MVC.UserInterface
{
    public class WebApiService
    {
        private WebApiService(string baseUri)
        {
            BaseUri = baseUri;
        }

        private static WebApiService _instance;

        public static WebApiService Instance
        {
            get { return _instance ?? (_instance = new WebApiService(ConfigurationManager.AppSettings["HE_ApiURI"])); }
        }

        public string BaseUri { get; private set; }

        //public async Task<T> AuthenticateAsync<T>(string userName, string password)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var result = await client.PostAsync(BuildActionUri("/Token"), new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
        //        {
        //            new KeyValuePair<string, string>("grant_type", "password"),
        //            new KeyValuePair<string, string>("userName", userName), 
        //            new KeyValuePair<string, string>("password", password)
        //        }));

        //        string json = await result.Content.ReadAsStringAsync();

        //        result.EnsureSuccessStatusCode();

        //        if (result.IsSuccessStatusCode)
        //        {
        //            return JsonConvert.DeserializeObject<T>(json);
        //        }
        //        //throw new ApiException(result.StatusCode, json);
        //        throw new Exception(json);
        //    }
        //}

        public async Task<TokenResponse>RetrieveToken(string userName, string password)
        {
            var client = new OAuth2Client(new Uri(BuildActionUri("/Token")));

            return await client.RequestResourceOwnerPasswordAsync(userName, password);
        }

        public async Task<T> GetAsync<T>(string action, string authToken = null)
        {
            using (var client = new HttpClient())
            {
                if (!authToken.IsNullOrWhiteSpace())
                {
                    //Add the authorization header
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
                }
                
                var result = await client.GetAsync(BuildActionUri(action));
                
                string json = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }

                throw new ApiException(result.StatusCode, json);
            }
        }

        public async Task PutAsync<T>(string action, T data, string authToken = null)
        {
            using (var client = new HttpClient())
            {
                if (!authToken.IsNullOrWhiteSpace())
                {
                    //Add the authorization header
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
                }

                var result = await client.PutAsJsonAsync(BuildActionUri(action), data);
                if (result.IsSuccessStatusCode)
                {
                    return;
                }

                string json = await result.Content.ReadAsStringAsync();
                throw new ApiException(result.StatusCode, json);
            }
        }

        public async Task PostAsync<T>(string action, T data, string authToken = null)
        {
            using (var client = new HttpClient())
            {
                if (!authToken.IsNullOrWhiteSpace())
                {
                    //Add the authorization header
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
                }

                var result = await client.PostAsJsonAsync(BuildActionUri(action), data);

                //result.EnsureSuccessStatusCode();

                if (result.IsSuccessStatusCode)
                {
                    return;
                }

                string json = await result.Content.ReadAsStringAsync();
                //throw new ApiException(result.StatusCode, json);
                throw new Exception(json);
            }
        }

        private string BuildActionUri(string action)
        {
            return BaseUri + action;
        }
    }
}
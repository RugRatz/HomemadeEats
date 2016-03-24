﻿using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using HE.API.Models;
using HE.WebApp.UserInterface.Models;

namespace HE.WebApp.UserInterface
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

        public async Task<T> AuthenticateAndGetTokenAsync<T>(string userName, string password)
        {
            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(BuildActionUri("/Token"), new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("userName", userName),
                    new KeyValuePair<string, string>("password", password)
                }));

                string json = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                return JsonConvert.DeserializeObject<T>(json);
                //throw new Exception(result.StatusCode + " " + JsonConvert.DeserializeObject<T>(json));
            }
        }

        public async Task<List<MealTypesViewModel>> GetAsync(string action, string authToken = null)
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
                    //var test = JsonConvert.DeserializeObject<List<MealTypesModel>>(json);
                    //var a = test;
                    return JsonConvert.DeserializeObject<List<MealTypesViewModel>>(json);
                }

                throw new Exception(result.StatusCode + " " + JsonConvert.DeserializeObject<List<MealTypesViewModel>>(json));
            }
        }

        //public async Task PutAsync<T>(string action, T data, string authToken = null)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        if (!authToken.IsNullOrWhiteSpace())
        //        {
        //            //Add the authorization header
        //            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
        //        }

        //        var result = await client.PutAsJsonAsync(BuildActionUri(action), data);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return;
        //        }

        //        string json = await result.Content.ReadAsStringAsync();
        //        throw new ApiException(result.StatusCode, json);
        //    }
        //}

        public async Task<HttpResponseMessage> PostAsync<T>(string action, T data, string authToken = null)
        {
            using (var client = new HttpClient())
            {
                if (!authToken.IsNullOrWhiteSpace())
                {
                    //Add the authorization header
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + authToken);
                }

                # region Instead of doing all of this, I prefer to return the result of the task then allow each action to process what it needs to
                // 
                //var result = await client.PostAsJsonAsync(BuildActionUri(action), data);

                //string json = await result.Content.ReadAsStringAsync();

                //if (result.IsSuccessStatusCode)
                //{
                //    return; //JsonConvert.DeserializeObject<T>(json);
                //}
                ////throw new Exception(result.StatusCode + " " + json);
                //return; //JsonConvert.DeserializeObject<T>(json);
                #endregion
                return await client.PostAsJsonAsync(BuildActionUri(action), data);
            }
        }

        private string BuildActionUri(string action)
        {
            return BaseUri + action;
        }
    }
}
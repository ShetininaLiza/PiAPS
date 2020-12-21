﻿using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PizzaAdmin
{
    public class APIClient
    {
        private static readonly HttpClient client = new HttpClient();
        static bool metka = false;
        
        public static void Connect()
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["IPAddress"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            metka = true;
        }

        public static T GetRequest<T>(string requestUrl)
        {
            var response = client.GetAsync(requestUrl);
            //MessageBox.Show(response.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            if (response.Result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                throw new Exception(result);
            }
        }

        public static void PostRequest<T>(string requestUrl, T model)
        {
            Console.WriteLine("PostRequest");
            var json = JsonConvert.SerializeObject(model);
            Console.WriteLine("json");
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine("Data: " + data);
            Console.WriteLine("client: " + client);
            var response = client.PostAsync(requestUrl,data);
            Console.WriteLine("response: " + response);
            //в форме регистрации ошибка
            var result = response.Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine("result: "+result);
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }
        public static bool GetContact()
        {
            return metka;
        }
    }
}

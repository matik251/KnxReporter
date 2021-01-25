﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static KnxReporter.Models.XmlFile;

namespace KnxReporter.Pages
{
    public class ApiService
    {
        public static void PostXmlFile(Xmlfile file)
        {
            Task.Run(async () => await PostEncodedTelegram(file)).Wait();
        }

        private static async Task PostEncodedTelegram(Xmlfile tosend)
        {

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient = new HttpClient(handler);
            var payload = JsonConvert.SerializeObject(tosend);
            payload = payload.Replace("\"Fid\":null,", "");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://192.168.1.200:1200/api/XmlFiles/PostXmlFiles");

            requestMessage.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var resultString = await responseMessage.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle error result
                throw new Exception();
            }
        }


        public async Task<string> ReplaceToSeriaolize(string xml)
        {
            Regex regex = new Regex("'||\r||\n", RegexOptions.Compiled);

            string removeByRegex = regex.Replace(xml, "'||\r||\n");
            return removeByRegex;
        }
    }
}

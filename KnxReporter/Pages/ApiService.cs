using KnxReporter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static KnxReporter.Models.XmlFile;

namespace KnxReporter.Pages
{
    public class ApiService
    {
        public static XmlFile PostXml(String filename, XmlDocument xml, int telegramCount)
        {
            XmlFile newFile = new XmlFile();
            newFile.FileName = filename;
            newFile.IsProcessed = 0;
            newFile.TelegramsCount = telegramCount;
            var temp = xml.OuterXml;
            try
            { 
                newFile.Xmldata = ReplaceToSerialize(temp.ToString());
            }
            catch(Exception e)
            {
                var tempEx = e;
            }
            return newFile;

        }

        //public static void PostXmlFile(XmlFile file)
        //{
        //    PostEncodedTelegram(file);
        //}

        //private static void PostEncodedTelegram(XmlFile tosend)
        //{
        //    try
        //    {
        //        HttpClientHandler handler = new HttpClientHandler();
        //        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        //        var httpClient = new HttpClient(handler);
        //        var payload = JsonConvert.SerializeObject(tosend);
        //        payload = payload.Replace("\"Fid\":null,", "");

        //        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://192.168.1.200:1200/api/XmlFiles/PostXmlFiles");

        //        requestMessage.Content = new StringContent(payload, Encoding.UTF8, "application/json");

        //        var responseMessage = await httpClient.SendAsync(requestMessage);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            var resultString = await responseMessage.Content.ReadAsStringAsync();
        //        }
        //        else
        //        {
        //            // Handle error result
        //            throw new Exception();
        //        }
        //    }catch(Exception e)
        //    {

        //    }
        //}


        public static string ReplaceToSerialize(string xml)
        {
            Regex regexNewline = new Regex("n?\n|\r", RegexOptions.Compiled);
            Regex regexDouble = new Regex("\"", RegexOptions.Compiled);

            string removeByRegex = regexDouble.Replace(xml, "'");
            removeByRegex = regexNewline.Replace(removeByRegex, "");
            return removeByRegex;
        }
    }
}

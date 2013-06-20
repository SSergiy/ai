using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using ServiceStack.Text.Json;
using RestSharp;
using ServiceStack.Text;
namespace Adapter
{
    public abstract class WebAPIBasisKlasse : IWebAPIAdapter
    {
        public string protokoll
        {
            get
            { return "http"; }
        }

        public string HostName
        {
            get { return "localhost"; }
        }

        public string api_pfad
        {
            get { return "api"; }
        }

        public abstract string port { get; }
        public abstract string controller { get; }

        public string Hole(int id)
        {
            var restclient = new RestClient();
            var client = new RestClient(protokoll + "://" +HostName + ":" + port);
            var request = new RestRequest(api_pfad + "/" + controller+  "/"+ id.ToString(), Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var queryResult = client.Execute(request);

            return queryResult.Content;
        }

        public string HoleAlle()
        {
            string return_value = default(string);
            using (WebClient client = new System.Net.WebClient())
            {
                var uri = erzeugeuri();
                byte[] response = client.DownloadData(uri);
                return_value = System.Text.Encoding.UTF8.GetString(response);
            }
            return return_value;
        }

        public void Lösche(int id)
        {
            using (WebClient client = new System.Net.WebClient())
            {
                var uri = erzeugeuri(id);
                client.UploadString(uri, "DELETE", "");
            }
        }

        public string Erstelle(IList<string> parameter)
        {
            var result_object = default(string);
            var client = new RestClient(protokoll + "://" +HostName + ":" + port);
            var request = new RestRequest(api_pfad + "/" + controller, Method.POST);

            //Json to post 
            string jsonToSend = parameter.ToArray<string>().ToJson();

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                result_object = response.Content;
            }
            return result_object;
        }
        private string erzeugeuri()
        {
            return protokoll + "://" + HostName + ":" + port + "/" + api_pfad + "/" + controller;
        }
        private string erzeugeuri(int id)
        {
            return erzeugeuri() + "/" + id.ToString();
        }

        public T Descerialize<T>(string json) { return TypeSerializer.DeserializeFromString<T>(json); }
    }
}

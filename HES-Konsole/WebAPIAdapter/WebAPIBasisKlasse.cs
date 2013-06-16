using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using ServiceStack.Text.Json;
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

        public T Hole<T>(int id)
        {
            T return_value = default(T);
            using (WebClient client = new System.Net.WebClient())
            {
                var uri = erzeugeuri(id);
                byte[] response = client.DownloadData(uri);
                string json = System.Text.Encoding.UTF8.GetString(response);
                return_value = (T)Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            }
            return return_value;


        }

        public IList<T> HoleAlle<T>()
        {
            List<T> return_value = new List<T>();
            using (WebClient client = new System.Net.WebClient())
            {
                var uri = erzeugeuri();
                byte[] response = client.DownloadData(uri);
                string json = System.Text.Encoding.UTF8.GetString(response);
                T[] elemente = (T[])Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                foreach (T elem in elemente)
                {
                    return_value.Add(elem);
                }
            }
            return return_value;
        }

        public void Lösche<T>(int id)
        {
            using (WebClient client = new System.Net.WebClient())
            {
                var uri = erzeugeuri(id);
                client.UploadString(uri, "DELETE", "");
            }
        }

        public T Erstelle<T>(IList<string> parameter)
        {
            var result_object = default(T);
            var uri = erzeugeuri();
            WebRequest request = WebRequest.Create(uri);
            request.Method = "POST";
            string postData = Newtonsoft.Json.JsonConvert.SerializeObject(parameter);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            if (responseFromServer.Length > 0)
            {
                result_object = (T)Newtonsoft.Json.JsonConvert.DeserializeObject(responseFromServer);
            }
            reader.Close();
            dataStream.Close();
            response.Close();
            return result_object;
        }
        private string erzeugeuri()
        {
            return protokoll + "://" + HostName + ";" + port + "/" + api_pfad + "/" + controller;
        }
        private string erzeugeuri(int id)
        {
            return erzeugeuri() + "/" + id.ToString();
        }
    }
}

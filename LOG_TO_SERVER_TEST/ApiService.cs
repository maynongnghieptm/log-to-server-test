using H.Socket.IO;
using RestSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LOG_TO_SERVER_TEST
{
    public class ApiService
    {
        RestClient client;

        public ApiService()
        {
            this.client = new RestClient("http://192.168.1.14:443");
        }

        public ApiService(RestClient client)
        {
            this.client = client;
        }

        public RestClient GetClient()
        {
            return client;
        }

        public void SetClient(RestClient client)
        {
            this.client = client;
        }

        public string sendJsonPostRequest(string endpoint, object requestBody)
        {
            RestRequest request = new RestRequest(endpoint);
            request.RequestFormat = DataFormat.Json;
            string jsonRequestBody = JsonSerializer.Serialize(requestBody);
            Debug.WriteLine("request body", requestBody);
            Debug.WriteLine("json", jsonRequestBody);
            request.AddJsonBody(jsonRequestBody);

            RestResponse response = this.client.Post(request);
            string content = "";
            if(response.Content != null)
            {
                content = response.Content;
            }
            Debug.WriteLine(content);
            return content;
        }

        //public string sendMultipartFormPostRequest(string endpoint, object requestBody, string bearerToken)
        //{
        //    RestRequest request = new RestRequest(endpoint, Method.Post);
        //    request.AddHeader("Content-Type", "multipart/form-data");
        //    request.AddHeader("Authorization", bearerToken);

        //    using JsonDocument jsonRequestBody = JsonDocument.Parse(JsonSerializer.Serialize(requestBody));

        //    // Add file and request body
        //    Debug.WriteLine(jsonRequestBody);


        //    RestResponse response = this.client.Post(request);
        //    string content = "";
        //    if (response.Content != null)
        //    {
        //        content = response.Content;
        //    }
        //    Debug.WriteLine(content);
        //    return content;
        //}
    }
}

using LOG_TO_SERVER_TEST.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LOG_TO_SERVER_TEST.Services
{
    public class TractorService
    {
        ApiService apiService;

        public TractorService()
        {

        }

        public TractorService(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public ApiService GetApiService()
        {
            return apiService;
        }

        public void SetApiService(ApiService apiService)
        {
            this.apiService = apiService;
        }

        // Method
        public Tractor[] GetAllTractors()
        {
            RestRequest request = new RestRequest("/tractors");
            request.RequestFormat = RestSharp.DataFormat.Json;
            RestResponse response = apiService.GetClient().Get(request);
            string content = "";
            if(response.Content != null)
            {
                content = response.Content;
            }
            MessageBox.Show(content);
            return new Tractor[] {new Tractor("123", "Nguyen  Hong Son")};
        }
    }
}

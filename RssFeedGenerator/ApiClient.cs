using Articles;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedGenerator
{
    public interface IFeedDataClient
    {
        List<Article> GetAllArticles();
    }
    
    public class ApiClient : IFeedDataClient
    {
        private string _apiKey;
        private string _apiEndPoint;
        private IApiSettings _apiSettings;

        public ApiClient(IApiSettings apiSettings)
            : this (apiSettings.ApiKey, apiSettings.ApiEndPoint)
        {
            _apiSettings = apiSettings;
        }

        public ApiClient(string apiKey, string apiEndPoint)
        {
            _apiKey = apiKey;
            _apiEndPoint = apiEndPoint;
        }

        public List<Article> GetAllArticles()
        {
            var client = new RestClient(_apiEndPoint);
            var request = new RestRequest("/article/all", Method.GET);
            request.AddHeader("api-key", _apiKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept-Charset", "UTF-8");
            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            var apiResponse = JsonConvert.DeserializeObject<Articles.Response>(content);

            var articles = apiResponse.payload.articles
                .OrderByDescending(a => a.publisheddate)
                .ToList();
            
            return articles;
        }
    }

    public class OfflineApiClient : IFeedDataClient
    {
        private IOfflineClientSettings _offlineClientSettings;

        public OfflineApiClient(IOfflineClientSettings offlineClientSettings)
        {
            _offlineClientSettings = offlineClientSettings;
        }

        public List<Article> GetAllArticles()
        {
            string content = System.IO.File.ReadAllText(_offlineClientSettings.LocalFilePath);
            
            var apiResponse = JsonConvert.DeserializeObject<Articles.Response>(content);

            var articles = apiResponse.payload.articles
                .OrderByDescending(a => a.publisheddate)
                .ToList();

            return articles;
        }
    }
}

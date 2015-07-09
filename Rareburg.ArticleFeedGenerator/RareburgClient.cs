using Articles;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IFeedDataClient
    {
        List<Article> GetAllArticles();
    }
    
    public class RareburgClient : IFeedDataClient
    {
        private string _apiKey;
        private string _apiEndPoint;
        private IApiSettings _apiSettings;

        public RareburgClient(IApiSettings apiSettings)
            : this (apiSettings.ApiKey, apiSettings.ApiEndPoint)
        {
            _apiSettings = apiSettings;
        }

        public RareburgClient(string apiKey, string apiEndPoint)
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

            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            var rareburgResponse = JsonConvert.DeserializeObject<Articles.Response>(content);

            var articles = rareburgResponse.payload.articles
                .OrderByDescending(a => a.publisheddate)
                .ToList();
            
            return articles;
        }
    }

    public class OfflineRareburgClient : IFeedDataClient
    {
        private IOfflineClientSettings _offlineClientSettings;

        public OfflineRareburgClient(IOfflineClientSettings offlineClientSettings)
        {
            _offlineClientSettings = offlineClientSettings;
        }

        public List<Article> GetAllArticles()
        {
            string content = System.IO.File.ReadAllText(_offlineClientSettings.LocalFilePath);
            
            var rareburgResponse = JsonConvert.DeserializeObject<Articles.Response>(content);

            var articles = rareburgResponse.payload.articles
                .OrderByDescending(a => a.publisheddate)
                .ToList();

            return articles;
        }
    }
}

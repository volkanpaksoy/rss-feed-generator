using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IApiSettings
    {
        string ApiKey { get; }

        string ApiEndPoint { get; }
    }

    public class AppConfigApiSettings : IApiSettings
    {
        public string ApiKey
        {
            get { return ConfigurationManager.AppSettings["Rareburg.ApiKey"]; }
        }

        public string ApiEndPoint
        {
            get { return ConfigurationManager.AppSettings["Rareburg.ApiEndPoint"]; }
        }
    }

    public class DynamoDBApiSettings : IApiSettings
    {
        private readonly string _tableName = "rareburg-article-feed-generator-config";
        private string _accessKey;
        private string _secretKey;
        private Table _configTable;

        public DynamoDBApiSettings(string accessKey, string secretKey)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;

            AmazonDynamoDBClient dynmamoClient = new AmazonDynamoDBClient(_accessKey, _secretKey, RegionEndpoint.EUWest1);
            _configTable = Table.LoadTable(dynmamoClient, _tableName);
        }

        public string ApiKey
        {
            get 
            {
                return GetValue("Rareburg.ApiKey");
            }
        }

        public string ApiEndPoint
        {
            get
            {
                return GetValue("Rareburg.ApiEndPoint");
            }
        }

        private string GetValue(string key)
        {
            return _configTable.GetItem(key).Values.First();
        }
    }
}

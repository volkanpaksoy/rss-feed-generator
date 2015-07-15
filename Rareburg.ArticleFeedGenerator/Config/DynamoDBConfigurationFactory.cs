using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class DynamoDBConfigurationFactory : IConfigurationFactory
    {
        private readonly string DYNAMODB_ACCESS_KEY = "AKIAJEERJAMDURVEWTYA";
        private readonly string DYNAMODB_SECRET_KEY = "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";
        private readonly string _tableName = "rareburg-article-feed-generator-config";
        protected Table _configTable;
       
        public DynamoDBConfigurationFactory()
        {
            AmazonDynamoDBClient dynmamoClient = new AmazonDynamoDBClient(DYNAMODB_ACCESS_KEY, DYNAMODB_SECRET_KEY, RegionEndpoint.EUWest1);
            _configTable = Table.LoadTable(dynmamoClient, _tableName);
        }
        
        public IApiSettings GetApiSettings()
        {
            return new DynamoDBApiSettings(_configTable);
        }

        public IFeedServiceSettings GetFeedServiceSettings()
        {
            return new DynamoDBFeedServiceSettings(_configTable);
        }

        public IFeedSettings GetFeedSettings()
        {
            return new DynamoDBFeedSettings(_configTable);
        }

        public IS3PublisherSettings GetS3PublisherSettings()
        {
            return new DynamoDBS3PublisherSettings(_configTable);
        }

        public IOfflineClientSettings GetOfflineClientSettings()
        {
            return new DynamoDBOfflineClientSettings(_configTable);
        }
    }
}

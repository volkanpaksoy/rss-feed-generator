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
        private readonly string _tableName = "rareburg-article-feed-generator-config";
        private readonly string APPLICATION_ID = "GUID";
        private readonly string DYNAMODB_ACCESS_KEY = "AKIAJEERJAMDURVEWTYA";
        private readonly string DYNAMODB_SECRET_KEY = "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";
        private Table _configTable;

        private IApiSettings _apiSettings;
        private IFeedServiceSettings _feedServiceSettings;
        private IFeedSettings _feedSettings;
        private IS3PublisherSettings _s3PublisherSettings;
        private IOfflineClientSettings _offlineClientSettings;

        public DynamoDBConfigurationFactory()
        {
            AmazonDynamoDBClient dynmamoClient = new AmazonDynamoDBClient(DYNAMODB_ACCESS_KEY, DYNAMODB_SECRET_KEY, RegionEndpoint.EUWest1);
            _configTable = Table.LoadTable(dynmamoClient, _tableName);
        }
        
        public IApiSettings GetApiSettings()
        {
            return new DynamoDBApiSettings(DYNAMODB_ACCESS_KEY, DYNAMODB_SECRET_KEY);
        }

        public IFeedServiceSettings GetFeedServiceSettings()
        {
            throw new NotImplementedException();
        }

        public IFeedSettings GetFeedSettings()
        {
            throw new NotImplementedException();
        }

        public IS3PublisherSettings GetS3PublisherSettings()
        {
            throw new NotImplementedException();
        }

        public IOfflineClientSettings GetOfflineClientSettings()
        {
            throw new NotImplementedException();
        }
    }
}

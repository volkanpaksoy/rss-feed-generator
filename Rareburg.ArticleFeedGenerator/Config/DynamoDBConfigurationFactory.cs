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
    public class DynamoDBConfigurationFactory : IConfigurationFactory
    {
        protected Table _configTable;
        
        public DynamoDBConfigurationFactory()
        {
            string accessKey = ConfigurationManager.AppSettings["DynamoDB.AccessKey"];
            string secretKey = ConfigurationManager.AppSettings["DynamoDB.SecretKey"];
            string tableName = ConfigurationManager.AppSettings["DynamoDB.TableName"];

            AmazonDynamoDBClient dynmamoClient = new AmazonDynamoDBClient(accessKey, secretKey, RegionEndpoint.EUWest1);
            _configTable = Table.LoadTable(dynmamoClient, tableName);
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

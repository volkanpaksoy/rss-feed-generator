using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationFactory configFactory = new AppConfigConfigurationFactory();
            // IConfigurationFactory configFactory = new DynamoDBConfigurationFactory();

            IApiSettings apiSettings = configFactory.GetApiSettings();
            IFeedSettings feedSettings = configFactory.GetFeedSettings();
            IFeedServiceSettings feedServiceSettings = configFactory.GetFeedServiceSettings();
            IS3PublisherSettings s3PublishSettings = configFactory.GetS3PublisherSettings();
            IOfflineClientSettings offlineClientSettings = configFactory.GetOfflineClientSettings();

            var rareburgClient = new OfflineRareburgClient(offlineClientSettings);
            var rareburgArticleFeedService = new RareburgArticleFeedService(feedServiceSettings);
            var publishService = new S3PublishService(s3PublishSettings, feedSettings);
            var feedGenerator = new ArticleFeedGenerator(rareburgClient, rareburgArticleFeedService, publishService, feedSettings);

            feedGenerator.Run();
        }
    }
}

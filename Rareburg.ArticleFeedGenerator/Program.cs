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
            var configFactory = new AppConfigConfigurationFactory();
            // var configFactory = new DynamoDBConfigurationFactory();
            // var rareburgClient = new RareburgClient(configFactory.GetApiSettings());
            var rareburgClient = new OfflineRareburgClient(configFactory.GetOfflineClientSettings());

            var feedSettings = configFactory.GetFeedSettings();
            var rareburgArticleFeedService = new RareburgArticleFeedService(configFactory.GetFeedServiceSettings());
            var publishService = new S3PublishService(configFactory.GetS3PublisherSettings(), feedSettings);
            var feedGenerator = new ArticleFeedGenerator(rareburgClient, rareburgArticleFeedService, publishService, feedSettings);
            feedGenerator.Run();
        }
    }
}

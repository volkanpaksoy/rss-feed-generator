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
            var configFactory = new AppConfigFactory();

            var feedFormatterFactory = new FeedFormatterFactory(configFactory.GetFeedSettings());
            // var rareburgClient = new RareburgClient(configFactory.GetApiSettings());
            var rareburgClient = new OfflineRareburgClient(configFactory.GetOfflineClientSettings());
            var rareburgArticleFeedService = new RareburgArticleFeedService(configFactory.GetFeedServiceSettings());
            var publishService = new S3PublishService(configFactory.GetS3PublisherSettings(), configFactory.GetFeedSettings());
            // var publishService = new FilePublishService(configFactory.GetFilePublisherSettings());

            var feedGenerator = new ArticleFeedGenerator(rareburgClient, rareburgArticleFeedService, publishService, feedFormatterFactory);
            feedGenerator.Run();
        }
    }
}

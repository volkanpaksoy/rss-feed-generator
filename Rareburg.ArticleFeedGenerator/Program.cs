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

            var feedDataClient = new OfflineRareburgClient(offlineClientSettings);
            var feedService = new RareburgArticleFeedService(feedServiceSettings);
            var publishService = new S3PublishService(s3PublishSettings, feedSettings);
            var feedGenerator = CreateFeedGenerator(feedDataClient, feedService, publishService, feedSettings);
            feedGenerator.Run();
        }

        private static ArticleFeedGenerator CreateFeedGenerator(
            IFeedDataClient feedDataClient,
            IFeedService feedService,
            IPublishService publishService,
            IFeedSettings feedSettings)
        {
            string feedFormat = feedSettings.FeedFormat;
            switch (feedFormat.ToLower())
            {
                case "atom": return new AtomFeedGenerator(feedDataClient, feedService, publishService, feedSettings);
                case "rss": return new RssFeedGenerator(feedDataClient, feedService, publishService, feedSettings);
                default: throw new ArgumentException("Unknown feed format");
            }
        }
    }
}

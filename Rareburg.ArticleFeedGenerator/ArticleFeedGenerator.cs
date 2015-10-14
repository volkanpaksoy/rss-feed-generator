using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class ArticleFeedGenerator
    {
        IPublishService _publishService;
        IFeedDataClient _feedDataClient;
        IFeedService _feedService;
        IFeedSettings _feedSettings;

        public ArticleFeedGenerator(IFeedDataClient feedDataClient, 
            IFeedService feedService, 
            IPublishService publishService,
            IFeedSettings feedSettings)
        {
            _feedDataClient = feedDataClient;
            _feedService = feedService;
            _publishService = publishService;
            _feedSettings = feedSettings;
        }
        
        public void Run()
        {
            var allArticles = _feedDataClient.GetAllArticles();
            var feed = _feedService.GetFeed(allArticles);
            var feedFormatterFactory = FeedFormatterFactory.CreateFactory(feed, _feedSettings);
            var feedFormatter = feedFormatterFactory.CreateFeedFormatter();
            _publishService.Publish(feedFormatter);
        }
    }
}

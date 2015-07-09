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
        IFeedFormatterFactory _feedFormatterFactory;

        public ArticleFeedGenerator(IFeedDataClient feedDataClient, IFeedService feedService, IPublishService publishService, IFeedFormatterFactory feedFormatterFactory)
        {
            _feedDataClient = feedDataClient;
            _feedService = feedService;
            _publishService = publishService;
            _feedFormatterFactory = feedFormatterFactory;
        }
        
        public void Run()
        {
            var allArticles = _feedDataClient.GetAllArticles();
            var feed = _feedService.GetFeed(allArticles);
            var feedFormatter = _feedFormatterFactory.CreateFeedFormatter(feed);
            _publishService.Publish(feedFormatter);
        }
    }
}

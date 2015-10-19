using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public abstract class ArticleFeedGenerator
    {
        protected SyndicationFeed _feed;
        private SyndicationFeedFormatter _feedFormatter;

        protected IPublishService _publishService;
        protected IFeedDataClient _feedDataClient;
        protected IFeedService _feedService;
        protected IFeedSettings _feedSettings;

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

        public abstract SyndicationFeedFormatter CreateFeedFormatter();

        public void Run()
        {
            var allArticles = _feedDataClient.GetAllArticles();
            _feed = _feedService.GetFeed(allArticles);
            
            _feedFormatter = CreateFeedFormatter();

            _publishService.Publish(_feedFormatter);
        }


    }
}

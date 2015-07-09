using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IFeedFormatterFactory
    {
        SyndicationFeedFormatter CreateFeedFormatter(SyndicationFeed feed);
    }

    public class FeedFormatterFactory : IFeedFormatterFactory
    {
        private IFeedSettings _feedSettings;

        public FeedFormatterFactory(IFeedSettings feedSettings)
        {
            _feedSettings = feedSettings;
        }
        
        public SyndicationFeedFormatter CreateFeedFormatter(SyndicationFeed feed)
        {
            string feedFormat = _feedSettings.FeedFormat;
            switch (feedFormat.ToLower())
            {
                case "atom": return new Atom10FeedFormatter(feed);
                case "rss": return new Rss20FeedFormatter(feed);
                default: throw new ArgumentException("Unknown feed format");
            }
        }
    }
}

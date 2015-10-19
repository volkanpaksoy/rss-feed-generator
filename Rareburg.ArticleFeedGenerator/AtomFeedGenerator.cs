using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class AtomFeedGenerator : ArticleFeedGenerator
    {
        public AtomFeedGenerator(IFeedDataClient feedDataClient,
            IFeedService feedService,
            IPublishService publishService,
            IFeedSettings feedSettings)
            : base(feedDataClient, feedService, publishService, feedSettings)
        {
        }

        public override SyndicationFeedFormatter CreateFeedFormatter()
        {
            return new Atom10FeedFormatter(_feed);
        }
    }
}

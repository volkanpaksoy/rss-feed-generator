using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RssFeedGenerator
{
    public class RssFeedGenerator : ArticleFeedGenerator
    {
        public RssFeedGenerator(IFeedDataClient feedDataClient,
            IFeedService feedService,
            IPublishService publishService,
            IFeedSettings feedSettings)
            : base(feedDataClient, feedService, publishService, feedSettings)
        {
        }

        public override SyndicationFeedFormatter CreateFeedFormatter()
        {
            var formatter = new Rss20FeedFormatter(_feed);
            formatter.SerializeExtensionsAsAtom = false;
            XNamespace atom = "http://www.w3.org/2005/Atom";
            _feed.AttributeExtensions.Add(new XmlQualifiedName("atom", XNamespace.Xmlns.NamespaceName), atom.NamespaceName);
            _feed.ElementExtensions.Add(new XElement(atom + "link", new XAttribute("href", _feedSettings.FeedUrl), new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml")));
            return formatter;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IFeedFormatterFactory
    {
        SyndicationFeedFormatter CreateFeedFormatter();
    }

    public class FeedFormatterFactory
    {
        public static IFeedFormatterFactory CreateFactory(SyndicationFeed feed, IFeedSettings feedSettings)
        {
            string feedFormat = feedSettings.FeedFormat;
            switch (feedFormat.ToLower())
            {
                case "atom": return new AtomFormatterFactory(feed);
                case "rss": return new RssFormatterFactory(feed, feedSettings);
                default: throw new ArgumentException("Unknown feed format");
            }
        }
    }

    public class AtomFormatterFactory : IFeedFormatterFactory
    {
        SyndicationFeed _feed;

        public AtomFormatterFactory(SyndicationFeed feed)
        {
            _feed = feed;
        }

        public SyndicationFeedFormatter CreateFeedFormatter()
        {
            return new Atom10FeedFormatter(_feed);
        }
    }

    public class RssFormatterFactory : IFeedFormatterFactory
    {
        SyndicationFeed _feed;
        IFeedSettings _feedSettings;

        public RssFormatterFactory(SyndicationFeed feed, IFeedSettings feedSettings)
        {
            _feed = feed;
            _feedSettings = feedSettings;
        }

        public SyndicationFeedFormatter CreateFeedFormatter()
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

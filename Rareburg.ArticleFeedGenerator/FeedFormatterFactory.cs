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
                case "rss":
                {
                    var formatter = new Rss20FeedFormatter(feed);
                    formatter.SerializeExtensionsAsAtom = false;
                    XNamespace atom = "http://www.w3.org/2005/Atom";
                    feed.AttributeExtensions.Add(new XmlQualifiedName("atom", XNamespace.Xmlns.NamespaceName), atom.NamespaceName);
                    feed.ElementExtensions.Add(new XElement(atom + "link", new XAttribute("href", _feedSettings.FeedUrl), new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml")));
                    return formatter;
                }
                default: throw new ArgumentException("Unknown feed format");
            }
        }
    }
}

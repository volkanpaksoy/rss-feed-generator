using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IFeedSettings
    {
        string FeedFormat { get; }
        string FeedUrl { get; }
    }

    public class AppConfigFeedSettings : IFeedSettings
    {
        public string FeedFormat
        {
            get { return ConfigurationManager.AppSettings["Feed.Format"]; }
        }

        public string FeedUrl
        {
            get { return ConfigurationManager.AppSettings["Feed.Url"]; }
        }
    }
}

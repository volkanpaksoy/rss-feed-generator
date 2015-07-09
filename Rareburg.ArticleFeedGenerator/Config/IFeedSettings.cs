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
    }

    public class AppConfigFeedSettings : IFeedSettings
    {
        public string FeedFormat
        {
            get { return ConfigurationManager.AppSettings["Feed.Format"]; }
        }
    }
}

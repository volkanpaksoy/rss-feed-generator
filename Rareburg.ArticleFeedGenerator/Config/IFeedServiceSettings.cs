using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IFeedServiceSettings
    {
        string Title { get; }
        string Description { get; }
        string BaseUri { get; }
        string Category { get; }
        string ArticleUrl { get; }
        string UserUrl { get; }
    }

    public class AppConfigFeedServiceSettings : IFeedServiceSettings
    {
        public string Title
        {
            get { return ConfigurationManager.AppSettings["FeedService.Title"]; }
        }

        public string Description
        {
            get { return ConfigurationManager.AppSettings["FeedService.Description"]; }
        }

        public string BaseUri
        {
            get { return ConfigurationManager.AppSettings["FeedService.BaseUri"]; }
        }
        
        public string Category
        {
            get { return ConfigurationManager.AppSettings["FeedService.Category"]; }
        }

        public string ArticleUrl
        {
            get { return ConfigurationManager.AppSettings["FeedService.ArticleUrl"]; }
        }

        public string UserUrl
        {
            get { return ConfigurationManager.AppSettings["FeedService.UserUrl"]; }
        }
    }
}

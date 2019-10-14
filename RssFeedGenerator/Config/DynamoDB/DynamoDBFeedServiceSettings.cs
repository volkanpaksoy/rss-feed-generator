using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedGenerator
{
    public class DynamoDBFeedServiceSettings : DynamoDBSettingsBase, IFeedServiceSettings
    {
        public DynamoDBFeedServiceSettings(Table configTable)
            : base(configTable)
        {
        }

        public string Title
        {
            get { return GetValue("FeedService.Title"); }
        }

        public string Description
        {
            get { return GetValue("FeedService.Description"); }
        }

        public string BaseUri
        {
            get { return GetValue("FeedService.BaseUri"); }
        }

        public string Category
        {
            get { return GetValue("FeedService.Category"); }
        }

        public string ArticleUrl
        {
            get { return GetValue("FeedService.ArticleUrl"); }
        }

        public string UserUrl
        {
            get { return GetValue("FeedService.UserUrl"); }
        }
    }
}

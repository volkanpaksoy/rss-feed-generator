using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class DynamoDBFeedSettings : DynamoDBSettingsBase, IFeedSettings
    {
        public DynamoDBFeedSettings(Table configTable)
            : base(configTable)
        {
        }

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

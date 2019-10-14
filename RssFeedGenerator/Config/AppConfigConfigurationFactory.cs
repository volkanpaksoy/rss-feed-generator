using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedGenerator
{
    public class AppConfigConfigurationFactory : IConfigurationFactory
    {
        public IApiSettings GetApiSettings()
        {
            return new AppConfigApiSettings();
        }

        public IFeedServiceSettings GetFeedServiceSettings()
        {
            return new AppConfigFeedServiceSettings();
        }

        public IFeedSettings GetFeedSettings()
        {
            return new AppConfigFeedSettings();
        }

        public IS3PublisherSettings GetS3PublisherSettings()
        {
            return new AppConfigS3PublisherSettings();
        }

        public IFilePublisherSettings GetFilePublisherSettings()
        {
            return new AppConfigFilePublisherSettings();
        }

        public IOfflineClientSettings GetOfflineClientSettings()
        {
            return new AppConfigOfflineClientSettings();
        }
    }
}

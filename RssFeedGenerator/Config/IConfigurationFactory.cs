using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedGenerator
{
    public interface IConfigurationFactory
    {
        IApiSettings GetApiSettings();
        IFeedServiceSettings GetFeedServiceSettings();
        IFeedSettings GetFeedSettings();
        IS3PublisherSettings GetS3PublisherSettings();
        IOfflineClientSettings GetOfflineClientSettings();
    }
}

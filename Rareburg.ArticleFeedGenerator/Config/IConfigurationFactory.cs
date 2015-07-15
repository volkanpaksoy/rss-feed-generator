using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedGenerator
{
    public interface IFeedSettings
    {
        string FeedFormat { get; }
        string FeedUrl { get; }
    }
}

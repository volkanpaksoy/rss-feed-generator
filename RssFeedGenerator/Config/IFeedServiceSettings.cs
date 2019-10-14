using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedGenerator
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
}

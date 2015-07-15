using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IS3PublisherSettings
    {
        string Region { get; }
        string BucketName { get; }
        string FileName { get; }
        string AccessKey { get; }
        string SecretKey { get; }
    }
}

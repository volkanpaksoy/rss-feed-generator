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

    public class AppConfigS3PublisherSettings : IS3PublisherSettings
    {
        public string Region
        {
            get { return ConfigurationManager.AppSettings["S3Publisher.Region"]; }
        }

        public string BucketName
        {
            get { return ConfigurationManager.AppSettings["S3Publisher.BucketName"]; }
        }
        
        public string FileName
        {
            get { return ConfigurationManager.AppSettings["S3Publisher.FileName"]; }
        }

        public string AccessKey
        {
            get { return ConfigurationManager.AppSettings["S3Publisher.AccessKey"]; }
        }

        public string SecretKey
        {
            get { return ConfigurationManager.AppSettings["S3Publisher.SecretKey"]; }
        }
    }
}

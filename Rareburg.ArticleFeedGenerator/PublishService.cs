using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IPublishService
    {
        void Publish(SyndicationFeedFormatter feedFormatter);
    }

    public class S3PublishService : IPublishService
    {
        IS3PublisherSettings _s3PublisherSettings;
        IFeedSettings _feedSettings;

        public S3PublishService(IS3PublisherSettings s3PublisherSettings, IFeedSettings feedSettings)
        {
            _s3PublisherSettings = s3PublisherSettings;
            _feedSettings = feedSettings;
        }

        public void Publish(SyndicationFeedFormatter feedFormatter)
        {
            var config = new AmazonS3Config
            {
                Timeout = TimeSpan.FromMinutes(5),
                ReadWriteTimeout = TimeSpan.FromMinutes(5),
                RegionEndpoint = RegionEndpoint.GetBySystemName(_s3PublisherSettings.Region)
            };

            IAmazonS3 s3Client = new AmazonS3Client(_s3PublisherSettings.AccessKey, _s3PublisherSettings.SecretKey, config);

            var memStream = new MemoryStream();
            var settings = new XmlWriterSettings(){ Encoding = Encoding.UTF8 };
            using (var writer = XmlWriter.Create(memStream, settings))
            {
                feedFormatter.WriteTo(writer);
            }

            using (var transferUtility = new TransferUtility(s3Client))
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    AutoCloseStream = true,
                    BucketName = _s3PublisherSettings.BucketName,
                    Key = string.Format(_s3PublisherSettings.FileName, DateTime.Now.ToString("yyyyMMddHHmmss")),
                    // Adding datetime for debugging purposess only. 
                    // In order for this to take effect change the config file to something like this
                    // <add key="S3Publisher.FileName" value="rareburg.articles.{0}.rss" />
                    ContentType = string.Format("application/{0}+xml", _feedSettings.FeedFormat),
                    CannedACL = S3CannedACL.PublicRead,
                    InputStream = memStream
                };

                transferUtility.Upload(uploadRequest);
            }
        }
    }

    public class FilePublishService : IPublishService
    {
        IFilePublisherSettings _filePublisherSettings;

        public FilePublishService(IFilePublisherSettings filePublisherSettings)
        {
            _filePublisherSettings = filePublisherSettings;
        }

        public void Publish(SyndicationFeedFormatter feedFormatter)
        {
            string targetFilePath = string.Format(_filePublisherSettings.OutputFilePath, DateTime.Now.ToString("yyyyMMddHHmmss"));
            using (var writer = XmlWriter.Create(targetFilePath))
            {
                feedFormatter.WriteTo(writer);
            }
        }
    }
}

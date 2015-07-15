using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class DynamoDBS3PublisherSettings : DynamoDBSettingsBase, IS3PublisherSettings
    {
        public DynamoDBS3PublisherSettings(Table configTable)
            : base(configTable)
        {
        }

        public string Region
        {
            get { return GetValue("S3Publisher.Region"); }
        }

        public string BucketName
        {
            get { return GetValue("S3Publisher.BucketName"); }
        }

        public string FileName
        {
            get { return GetValue("S3Publisher.FileName"); }
        }

        public string AccessKey
        {
            get { return GetValue("S3Publisher.AccessKey"); }
        }

        public string SecretKey
        {
            get { return GetValue("S3Publisher.SecretKey"); }
        }
    }
}

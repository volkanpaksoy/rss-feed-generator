using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator.Config.AppConfig
{
    public class DynamoDBFilePublisherSettings : DynamoDBSettingsBase, IFilePublisherSettings
    {
        public DynamoDBFilePublisherSettings(Table configTable)
            : base(configTable)
        {
        }

        public string OutputFilePath
        {
            get { throw new NotImplementedException(); }
        }
    }
}

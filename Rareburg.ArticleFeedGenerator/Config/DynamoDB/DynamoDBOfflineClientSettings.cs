using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class DynamoDBOfflineClientSettings : DynamoDBSettingsBase, IOfflineClientSettings
    {
        public DynamoDBOfflineClientSettings(Table configTable)
            : base (configTable)
        {
        }
    
        public string LocalFilePath
        {
            get { return GetValue("Rareburg.LocalFilePath"); }
        }
    }
}

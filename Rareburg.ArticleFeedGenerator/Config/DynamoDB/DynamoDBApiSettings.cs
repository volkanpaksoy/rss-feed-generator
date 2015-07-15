using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class DynamoDBApiSettings : DynamoDBSettingsBase, IApiSettings
    {
        public DynamoDBApiSettings(Table configTable)
            : base (configTable)
        {
        }

        public string ApiKey
        {
            get { return GetValue("Rareburg.ApiKey"); }
        }

        public string ApiEndPoint
        {
            get { return GetValue("Rareburg.ApiEndPoint"); }
        }
    }
}

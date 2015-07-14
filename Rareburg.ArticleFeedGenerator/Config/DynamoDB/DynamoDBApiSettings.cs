using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class DynamoDBApiSettings : IApiSettings
    {
        private Table _configTable;

        public DynamoDBApiSettings(Table configTable)
        {
            _configTable = configTable;
        }

        public string ApiKey
        {
            get
            {
                return GetValue("Rareburg.ApiKey");
            }
        }

        public string ApiEndPoint
        {
            get
            {
                return GetValue("Rareburg.ApiEndPoint");
            }
        }

        private string GetValue(string key)
        {
            return _configTable.GetItem(key).Values.First();
        }
    }
}

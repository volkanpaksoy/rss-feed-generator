using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public class DynamoDBSettingsBase
    {
        private Table _configTable;

        public DynamoDBSettingsBase(Table configTable)
        {
            _configTable = configTable;
        }

        protected string GetValue(string key)
        {
            return _configTable.GetItem(key).Values.First();
        }
    }
}

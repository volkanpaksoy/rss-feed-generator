using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedGenerator
{
    public class AppConfigFilePublisherSettings : IFilePublisherSettings
    {
        public string OutputFilePath
        {
            get { return ConfigurationManager.AppSettings["FilePublisher.OutputFilePath"]; }
        }
    }
}

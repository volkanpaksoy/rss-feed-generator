using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IApiSettings
    {
        string ApiKey { get; }

        string ApiEndPoint { get; }
    }

    public class AppConfigApiSettings : IApiSettings
    {
        public string ApiKey
        {
            get { return ConfigurationManager.AppSettings["Rareburg.ApiKey"]; }
        }

        public string ApiEndPoint
        {
            get { return ConfigurationManager.AppSettings["Rareburg.ApiEndPoint"]; }
        }
    }

}

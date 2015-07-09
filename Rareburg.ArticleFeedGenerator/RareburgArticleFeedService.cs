using Articles;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace Rareburg.ArticleFeedGenerator
{
    public interface IFeedService
    {
        SyndicationFeed GetFeed(List<Article> articles);
    }
    
    public class RareburgArticleFeedService : IFeedService
    {
        IFeedServiceSettings _feedServiceSettings;

        public RareburgArticleFeedService(IFeedServiceSettings feedServiceSettings)
        {
            _feedServiceSettings = feedServiceSettings;
        }

        public SyndicationFeed GetFeed(List<Article> articles)
        {
            SyndicationFeed feed = new SyndicationFeed(_feedServiceSettings.Title, _feedServiceSettings.Description, new Uri(_feedServiceSettings.BaseUri));
            feed.Title = new TextSyndicationContent(_feedServiceSettings.Title);
            feed.Description = new TextSyndicationContent(_feedServiceSettings.Description);
            feed.BaseUri = new Uri(_feedServiceSettings.BaseUri);
            feed.Categories.Add(new SyndicationCategory(_feedServiceSettings.Category));

            var items = new List<SyndicationItem>();
            foreach (var article in articles
                .Where(a => a.ispublished)
                .Where(a => a.ispubliclyvisible)
                .OrderByDescending(a => a.publisheddate))
            {
                var item = new SyndicationItem(article.title, 
                    article.bodysnippet,
                    new Uri (string.Format(_feedServiceSettings.ArticleUrl, article.slug)),
                    article.articleid.ToString(),
                    article.publisheddate);
                
                item.Authors.Add(new SyndicationPerson("", article.authorname, string.Format(_feedServiceSettings.UserUrl, article.user.username)));
                items.Add(item);
            }
            
            feed.Items = items;
            return feed;
        }
    }
}

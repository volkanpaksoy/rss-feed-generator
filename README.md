# Rareburg Article Feed Generator

A simple tool to create RSS/Atom feed for [Rareburg Knowledge Base](https://www.rareburg.com/knowledge)

### Implementation details
Details about the project can be found in my blog post: http://volkanpaksoy.com/archive/2015/07/11/rss-feed-generation-with-csharp/

### Configuration
Create a copy of App.config.sample and rename it to App.config. Set the actual values like S3 keys, API keys etc.

To use it offline, build the ArticleFeedGenerator class with OfflineRareburgClient and FilePublish Service:

```chsarp
var configFactory = new AppConfigFactory();

var feedFormatterFactory = new FeedFormatterFactory(configFactory.GetFeedSettings());
var rareburgClient = new OfflineRareburgClient(configFactory.GetOfflineClientSettings());
var rareburgArticleFeedService = new RareburgArticleFeedService(configFactory.GetFeedServiceSettings());
var publishService = new FilePublishService(configFactory.GetFilePublisherSettings());

var feedGenerator = new ArticleFeedGenerator(rareburgClient, rareburgArticleFeedService, publishService, feedFormatterFactory);
feedGenerator.Run();
```

This way it will read the API response from a given file and save the feed to a local file. Both values must be set in the App.config first.





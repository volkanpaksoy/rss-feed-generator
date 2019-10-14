using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Articles
{
    public class Response
    {
        public Payload payload { get; set; }
        public string session { get; set; }
    }

    public class Payload
    {
        public List<Article> articles { get; set; }
    }

    public class Article
    {
        [JsonProperty("author-name")]
        public string authorname { get; set; }
        public List<string> tags { get; set; }
        public string slug { get; set; }

        [JsonProperty("published-fuzzy-date")]
        public string publishedfuzzydate { get; set; }
        
        [JsonProperty("published-date")]
        public DateTime publisheddate { get; set; }

        [JsonProperty("is-publicly-visible?")]
        public bool ispubliclyvisible { get; set; }

        [JsonProperty("article-id")]
        public long articleid { get; set; }
        public string title { get; set; }

        [JsonProperty("body-snippet")]
        public string bodysnippet { get; set; }

        [JsonProperty("is-published?")]
        public bool ispublished { get; set; }
        public List<Category> categories { get; set; }

        [JsonProperty("body-intro")]
        public string bodyintro { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string avatar { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public string slug { get; set; }
    }
}
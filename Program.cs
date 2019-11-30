using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Models.DTO.QueryDTO;

namespace TwitterConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Auth.SetUserCredentials("IvR2TNrhUbmuEcuhq2sEnMoNc", "J3a6osLZS30v0w1avKat0p0lsG6Vdpm9hXGfDQdAvj5UgXNgxC", 
                "702224894101209088-WTZhr2j2dfPfEdO9DT9INIOqjDmyU2i", "2OXBCh9yHJXJkLkWu3rWUUYyFaLqq9Na2ZRoIUdtYuhwh");

            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;

            string[] searchFilter = { "#openbanking", "#apifirst", "#devops", "#cloudfirst", "#microservices",
                "#apigateway", "#oauth", "#swagger", "#raml", "#openapis"};

            foreach(string hashtag in searchFilter)
            {
                var searchParameter = Search.CreateTweetSearchParameter(hashtag);
                searchParameter.SearchType = SearchResultType.Recent;
                searchParameter.MaximumNumberOfResults = 100;

                var tweets = Search.SearchTweets(searchParameter);

                SaveTweets(tweets, hashtag);

                Console.WriteLine($"hashtag {hashtag} salva no banco. Quantidade de posts: {tweets.ToList().Count.ToString()}");
            }

            Console.ReadKey();
        }

        public static void SaveTweets(IEnumerable<ITweet> tweets, string hashTag)
        {
            DB dataBase = new DB();

            //TODO: include tweet id in the columns

            foreach (var tweet in tweets)
            {
                dataBase.Insert(new Tweet(tweet.Id, tweet.CreatedBy.ToString(), tweet.CreatedBy.FollowersCount.ToString(),
                    hashTag, tweet.CreatedAt.ToString(), tweet.Language.ToString()));
            }
        }
    }
}

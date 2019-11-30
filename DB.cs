using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace TwitterConsumer
{
    public class DB
    {
        private readonly IMongoCollection<Tweet> _tweets;
        private readonly string connectionString = "mongodb://127.0.0.1:27017";
        private readonly string databaseName = "TweetsDB";
        private readonly string tweetsCollectionName = "tweets";

        public DB()
        {
            var client = new MongoClient(connectionString);
            var dataBase = client.GetDatabase(databaseName);

            _tweets = dataBase.GetCollection<Tweet>(tweetsCollectionName);
        }

        public void Insert(Tweet tweet)
        {
            try
            {
                if (!Exists(tweet.TweetId)) 
                    _tweets.InsertOne(tweet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool Exists(long tweetId)
        {
            return _tweets.Find(Builders<Tweet>.Filter.Eq("TweetId", tweetId)).ToList().Count > 0 ? true : false;
        }
    }
}

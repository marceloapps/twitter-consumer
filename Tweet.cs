using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TwitterConsumer
{
    public class Tweet
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("TweetId")]
        [BsonRequired()]
        public long TweetId { get; set; }

        [BsonElement("User")]
        [BsonRequired()]
        public string User { get; set; }

        [BsonElement("FollowersCount")]
        [BsonRequired()]
        public string FollowersCount { get; set; }

        [BsonElement("Hashtag")]
        [BsonRequired()]
        public string Hashtag { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired()]
        public string CreationDate { get; set; }

        [BsonElement("Language")]
        [BsonRequired()]
        public string Language { get; set; }

        public Tweet(long tweetId, string user, string followersCount, string hashTag, string creationDate, string language)
        {
            TweetId = tweetId;
            User = user;
            FollowersCount = followersCount;
            Hashtag = hashTag;
            CreationDate = creationDate;
            Language = language;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using HotelAdvisor.BLL.Model;
using HotelAdvisor.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HotelAdvisor.Dal
{
    public class HotelProvider : IHotelProvider
    {
        public Hotel GetHotelById(string hotelId)
        {
            var connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            //sid mongo db name
            var database = server.GetDatabase("newhotelsdb");
            var hotelCollection = database.GetCollection<Hotel>("hotel");

            return hotelCollection.FindOneByIdAs<Hotel>(ObjectId.Parse(hotelId));

            //var database = server.GetDatabase("new_hoteladvisor");
            //var hotelCollection = database.GetCollection<Hotel>("hoteldetails");
            //var id = ObjectId.Parse(hotelId);
            //return hotelCollection.FindOneById(id);
        }

        public List<Review> GetReviewsByHotelId(string hotelId)
        {
            const string connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            //sid mongo db name
            var database = server.GetDatabase("newhotelsdb");
            var reviewCollection = database.GetCollection<Review>("review");

            //saif mongo db
            //var database = server.GetDatabase("new_hoteladvisor");
            //var reviewCollection = database.GetCollection<Review>("reviews");

            var reviewQuery = Query.EQ("HotelId", hotelId);
            var mongoReviews = reviewCollection.Find(reviewQuery);
            return mongoReviews.ToList();
        }

        public bool AddReview(string hotelId, Review review)
        {
            const string connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("newhotelsdb");
            var collection = database.GetCollection<Review>("review");
            review.HotelId = hotelId;
            try
            {
                collection.Insert(review);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<Hotel> FetchHotelsByIdList(List<string> hotelIds)
        {
            const string connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("newhotelsdb");
            var collection = database.GetCollection<Hotel>("hotel");
            return hotelIds.Select(id => collection.FindOneById(ObjectId.Parse(id))).ToList();
        }

        public List<Hotel> GetTopHotels(int NumberOfHotels)
        {
            //var hotelList = new List<Hotel>(number);
            //int count = 0;

            //var connectionString = "mongodb://localhost";
            //var client = new MongoClient(connectionString);
            //var server = client.GetServer();

            ////sid mongo db name
            //var database = server.GetDatabase("newhotelsdb");
            //var hotelCollection = database.GetCollection<Hotel>("hotel");

            //var result = (from h in hotelCollection.AsQueryable<Hotel>()
            //              orderby h.Rating
            //              select h                          
            //              );

            //foreach (var hotel in result)
            //{
            //    hotelList.Add(hotel);
            //    if (count++ >= number)
            //        break;
            //}
            //return hotelList;

            var connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("newhotelsdb");
            var reviewsCollection = database.GetCollection("review");
            var hotelsCollection = database.GetCollection<Hotel>("hotel");
            List<BsonDocument> matches = new List<BsonDocument>();
            matches.Add(new BsonDocument
                {
                    {
                         "$group",new BsonDocument{   
                                                    {"_id","$HotelId"},
                                                    {"AvgRating",new BsonDocument
                                                                 {
                                                                    {"$avg","$Rating"}
                                                                 }
                                                    },
                                                    {
                                                        "NoOfReviews", new BsonDocument
                                                                      { 
                                                                       {"$sum", 1 }
                                                                      }
                                                    }
                                                }
                        
                     }
                    });
            matches.Add(
              new BsonDocument{
                {
                   "$sort",new BsonDocument
                        {
                            {"'NoOfReviews'",-1},
                            {"'AvgRating'",-1}
                        }
                }
                });
            matches.Add(
                new BsonDocument
                {
                    {
                          "$limit", NumberOfHotels
                    }
                });
            var pipeline = matches.ToList();
            var result = reviewsCollection.Aggregate(pipeline);
            List<Hotel> topHotels = new List<Hotel>();
            foreach (var item in result.ResultDocuments)
            {
                var query_id = Query.EQ("_id", ObjectId.Parse(item.GetElement(0).Value.ToString()));
                topHotels.Add(hotelsCollection.FindOne(query_id));
            }
            return topHotels;

        }
    }
}

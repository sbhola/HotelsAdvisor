using System;
﻿using HotelAdvisor.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HotelAdvisor.Dal
{
    public class HotelEditor : IHotelEditor
    {
        public bool DeleteReview(string reviewId)
        {
            const string connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("newhotelsdb");
            var collection = database.GetCollection<HotelAdvisor.BLL.Model.Review>("review");

            var query_id = MongoDB.Driver.Builders.Query.EQ("_id", ObjectId.Parse(reviewId));
           
            try
            {
                collection.Remove(query_id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool UpdateReview(string hotelId, BLL.Model.Review review)
        {
            var connectionString = "mongodb://lab22";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("newhotelsdb");
            var collection = database.GetCollection<HotelAdvisor.BLL.Model.Review>("review");

            var query_id = Query.EQ("HotelId", hotelId);

            var mongoReviewToBeUpdated = collection.FindOne(query_id);

            //If Review Does not exist for given hotelId in the database,return False.
            if (mongoReviewToBeUpdated == null)
            {
                return false;
            }
            mongoReviewToBeUpdated.Location = review.Location;
            mongoReviewToBeUpdated.Rating = review.Rating;
            mongoReviewToBeUpdated.Rooms = review.Rooms;
            mongoReviewToBeUpdated.Service = review.Service;
            mongoReviewToBeUpdated.Title = review.Title;
            mongoReviewToBeUpdated.UserName = review.UserName;
            mongoReviewToBeUpdated.UtcTimeSubmitted = review.UtcTimeSubmitted;
            mongoReviewToBeUpdated.Value = review.Value;
            mongoReviewToBeUpdated.Cleanliness = review.Cleanliness;
            mongoReviewToBeUpdated.Description = review.Description;

            try
            {
                collection.Save(mongoReviewToBeUpdated);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}

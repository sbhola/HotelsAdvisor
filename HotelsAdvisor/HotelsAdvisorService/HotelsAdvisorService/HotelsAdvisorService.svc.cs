using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using HotelAdvisor.Dal;
using HotelAdvisor.Interfaces;
using HotelAdvisor.Services.ServiceContracts;
using HotelAdvisor.Services.DataContracts;
using HotelsAdvisorService.Translator;

namespace HotelsAdvisorService
{
    public class HotelsAdvisorService : IHotelsAdvisor
    {
        public Hotel GetHotelById(string hotelId)
        {
            try
            {
                IHotelProvider hotelProvider = new HotelProvider();

                if (string.IsNullOrEmpty(hotelId))
                {
                    var fault = new HotelDoesNotExistFault
                    {
                        FaultId = 101,
                        Message = "HotelId is Null or Empty."
                    };
                    throw new FaultException<HotelDoesNotExistFault>(fault, "HotelId is NULL/Empty.");
                }

                //get the hotel document from mongoDB
                var mongoHotel = hotelProvider.GetHotelById(hotelId);

                if (mongoHotel == null)
                {
                    var fault = new HotelDoesNotExistFault
                    {
                        FaultId = 102,
                        Message = "Hotel Does not exists in the Database."
                    };
                    throw new FaultException<HotelDoesNotExistFault>(fault, "Hotel does not exist.");
                }

                if (mongoHotel.ImageList.Count < 20)
                {
                    while (mongoHotel.ImageList.Count <= 20)
                    {
                        mongoHotel.ImageList.Add("http://nancyharmonjenkins.com/wp-content/plugins/nertworks-all-in-one-social-share-tools/images/no_image.png");
                    }
                }

                //get the reviews document from mongoDB
                var mongoReviews = hotelProvider.GetReviewsByHotelId(hotelId);

                
                //convert mongo hotel to data contract hotel
                var hotel = mongoHotel.ToDataContract();

                List<HotelAdvisor.Services.DataContracts.Review> reviews = new List<Review>();

                //convert the mongo reviews into data contract review type and add them in review list
                foreach (var review in mongoReviews)
                {   
                    reviews.Add(review.ToDataContract());
                }

                //add the reviews list into data contract hotel object
                hotel.Reviews = reviews; 

                return hotel;
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception)
            {
                //Log error
                throw new FaultException<HotelDoesNotExistFault>(new HotelDoesNotExistFault(),
                    "Hotel does not exist.");
            }
        }


        public bool AddReview(string hotelId, Review review)
        {
            try
            {
                IHotelProvider hotelProvider = new HotelProvider();

                if (string.IsNullOrEmpty(hotelId))
                {
                    var fault = new CustomFaults
                        {
                            FaultCode = 101,
                            FaultMessage = "HotelId is Null or Empty."
                        };
                    throw new FaultException<CustomFaults>(fault, "HotelId is NULL/Empty.");
                }

                if (review == null)
                {
                    var fault = new CustomFaults
                    {
                        FaultCode = 101,
                        FaultMessage = "Review Cannot be Null"
                    };
                    throw new FaultException<CustomFaults>(fault, fault.FaultMessage);
                }

                var reviewMongo = review.FromDataContract();

                bool status = hotelProvider.AddReview(hotelId, reviewMongo);

                if (status == false)
                {
                    var fault = new CustomFaults
                        {
                            FaultCode = 102,
                            FaultMessage = "Hotel Does not exists in the Database."
                        };
                    throw new FaultException<CustomFaults>(fault, "Hotel does not exist.");
                }
                return true;
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception)
            {
                //Log error
                var fault = new CustomFaults
                    {
                        FaultCode = 104,
                        FaultMessage = "Hotel Id Inappropriate or Hotel Not Found"
                    };
                throw new FaultException<CustomFaults>(fault, "Hotel Id Inappropriate or Hotel Not Found");
            }
        }

        public List<HotelModelForIntermediatePage> FetchHotelsByIdList(List<string> hotelIds)
        {
            IHotelProvider hotelProvider = new HotelProvider();
            if (hotelIds == null || hotelIds.Contains(null))
            {
                var fault = new CustomFaults
                {
                    FaultCode = 107,
                    FaultMessage = "HotelId Cannot Get Null"
                };

                throw new FaultException<CustomFaults>(fault, fault.FaultMessage);
            }

            var hotel = hotelProvider.FetchHotelsByIdList(hotelIds);

            var list = new List<HotelModelForIntermediatePage>();
            foreach (var id in hotel)
            {
                try
                {
                    var hotelListing = id.ToDataContractForIntermediateHotelListing();

                    list.Add(hotelListing);
                }
                catch
                {
                    var fault = new CustomFaults
                    {
                        FaultCode = 106,
                        FaultMessage = "Invalid HotelId, Cannot Get Hotel"
                    };
                    throw new FaultException<CustomFaults>(fault, fault.FaultMessage);
                }
            }
            return list;

        }

        public List<Hotel> GetTopHotels(int number)
        {
            IHotelProvider hotelProvider = new HotelProvider();
            var mongoHotelsList = hotelProvider.GetTopHotels(number);
            var hotelList = new List<Hotel>();
            foreach (var hotel in mongoHotelsList)
            {
                if (hotel.ImageList == null)
                    hotel.ImageList.Add("http://nancyharmonjenkins.com/wp-content/plugins/nertworks-all-in-one-social-share-tools/images/no_image.png");
                hotelList.Add(hotel.ToDataContract());
            }

            //var hotel = mongoHotelsList.ToDataContract();
            return hotelList;
        }

        public bool DeleteReview(string reviewId)
        {
            if (string.IsNullOrEmpty(reviewId))
            {
                var fault = new ParameterNullException
                {
                    FaultId = 202,
                    Message = "ReviewId received is NULL."
                };
                throw new FaultException<ParameterNullException>(fault, "ReviewId is NULL.");
            }

            IHotelEditor hotelEditor = new HotelEditor();
            try
            {
                if (hotelEditor.DeleteReview(reviewId))
                    return true;
                return false;
            }
            catch
            {
                throw;
            }

        }

        public bool UpdateReview(string hotelId, Review review)
        {
            //throw is hotelId is NULL or EMPTY STRINGg
            if (string.IsNullOrEmpty(hotelId))
            {
                var fault = new ParameterNullException
                {
                    FaultId = 201,
                    Message = "HotelId received is NULL."
                };
                throw new FaultException<ParameterNullException>(fault, "HotelId is NULL.");
            }

            //throw if review object is NULL
            if (review == null)
            {
                var fault = new ParameterNullException
                {
                    FaultId = 205,
                    Message = "Review Object received is NULL."
                };
                throw new FaultException<ParameterNullException>(fault, "Review Object is NULL.");
            }

            HotelAdvisor.BLL.Model.Review BLLReview = new HotelAdvisor.BLL.Model.Review
            {
                Cleanliness = review.Cleanliness,
                Description = review.Description,
                HotelId = hotelId,
                Location = review.Location,
                Rating = review.Rating,
                Rooms = review.Rooms,
                Service = review.Service,
                Title = review.Title,
                UserName = review.UserName,
                UtcTimeSubmitted = review.UtcTimeSubmitted,
                Value = review.Value
            };
            
            IHotelEditor hotelEditor = new HotelEditor();
            try
            {
                if (hotelEditor.UpdateReview(hotelId, BLLReview))
                    return true;
                return false;
            }
            catch
            {
                throw;
            }       
        }
    }
}

using System.Collections.Generic;
using DataContract = HotelAdvisor.Services.DataContracts;
using Model = HotelAdvisor.BLL.Model;

namespace HotelsAdvisorService.Translator
{
    public static class Extensions
    {
        public static DataContract.Hotel ToDataContract(this Model.Hotel obj)
        {
            return obj == null ? null :
                new DataContract.Hotel
                {
                    Address = obj.Address,
                    City = obj.City,
                    Country = obj.Country,
                    Id = obj.Id.ToString(),
                    ImageList = obj.ImageList,
                    Latitude = obj.Latitude,
                    Longitude = obj.Longitude,
                    Name = obj.Name,
                    Rating = obj.Rating,
                    Description=obj.Description,
                    StateCode = obj.StateCode,
                    UtcTimeSubmitted = obj.UtcTimeSubmitted
                };
        }

        public static List<DataContract.Review> ToDataContract(this List<Model.Review> obj)
        {
            return obj == null ? null :
                obj.ConvertAll<DataContract.Review>(ToDataContract);
        }

        public static DataContract.HotelModelForIntermediatePage ToDataContractForIntermediateHotelListing(this Model.Hotel obj)
        {
            return obj == null ? null :
                new DataContract.HotelModelForIntermediatePage
                {
                    Address = obj.Address,
                    City = obj.City,
                    Country = obj.Country,
                    HotelId = obj.Id.ToString(),
                    Image = obj.ImageList[0],
                    Name = obj.Name,
                    Rating = obj.Rating,
                    State = obj.StateCode,
                };
        }


        public static DataContract.Review ToDataContract(this Model.Review obj)
        {
            return obj == null ? null :
                new DataContract.Review
                {
                   
                    Cleanliness = obj.Cleanliness,
                    Description = obj.Description,
                    Location = obj.Location,
                    Rating = obj.Rating,
                    Id = obj.Id.ToString(),
                    HotelId = obj.HotelId,
                    Rooms = obj.Rooms,
                    Service = obj.Service,
                    Title = obj.Title,
                    UserName = obj.UserName,
                    UtcTimeSubmitted = obj.UtcTimeSubmitted,
                    Value = obj.Value
                };
        }

        public static Model.Review FromDataContract(this DataContract.Review obj)
        {
            return obj == null ? null :
                new Model.Review
                {
                    Cleanliness = obj.Cleanliness,
                    Description = obj.Description,
                    Location = obj.Location,
                    Rating = obj.Rating,
                    Rooms = obj.Rooms,
                    Service = obj.Service,
                    Title = obj.Title,
                    UserName = obj.UserName,
                    UtcTimeSubmitted = obj.UtcTimeSubmitted,
                    Value = obj.Value,
                    HotelId = obj.HotelId
                };
        }

    }
}
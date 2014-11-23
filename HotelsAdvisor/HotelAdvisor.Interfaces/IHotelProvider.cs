using HotelAdvisor.BLL.Model;
using System.Collections.Generic;


namespace HotelAdvisor.Interfaces
{
    public interface IHotelProvider
    {
        Hotel GetHotelById(string hotelId);

        List<Review> GetReviewsByHotelId(string hotelId);

        bool AddReview(string hotelId, Review review);

        List<Hotel> FetchHotelsByIdList(List<string> hotelIds);

        List<Hotel> GetTopHotels(int number);

    }
}

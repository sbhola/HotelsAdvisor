using System.Collections.Generic;
using System.ServiceModel;
using HotelAdvisor.Services.DataContracts;

namespace HotelAdvisor.Services.ServiceContracts
{
    [ServiceContract]
    public interface IHotelsAdvisor
    {
        [OperationContract]
        [FaultContract(typeof(HotelDoesNotExistFault))]
        [FaultContract(typeof(ParameterNullException))]
        Hotel GetHotelById(string id);

        [OperationContract]
        [FaultContract(typeof(CustomFaults))]
        bool AddReview(string hotelId, Review review);

        [OperationContract]
        [FaultContract(typeof(CustomFaults))]
        List<HotelModelForIntermediatePage> FetchHotelsByIdList(List<string> hotelIds);

        [OperationContract]
        [FaultContract(typeof(CustomFaults))]
        List<Hotel> GetTopHotels(int number);

        [OperationContract]
        [FaultContract(typeof(HotelDoesNotExistFault))]
        [FaultContract(typeof(ParameterNullException))]
        bool DeleteReview(string reviewId);

        [OperationContract]
        [FaultContract(typeof(HotelDoesNotExistFault))]
        [FaultContract(typeof(ParameterNullException))]
        [FaultContract(typeof(ReviewDoesNotExistFault))]
        bool UpdateReview(string hotelId, Review review);
    }
}


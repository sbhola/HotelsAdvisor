namespace HotelAdvisor.Services.DataContracts
{
    
    public class HotelDoesNotExistFault
    {
        
        public int FaultId { get; set; }
        
        public string Message { get; set; }
    }

    
    public class ParameterNullException
    {
        
        public int FaultId { get; set; }
        
        public string Message { get; set; }
    }

    
    public class ReviewDoesNotExistFault
    {
        
        public int FaultId { get; set; }
        
        public string Message { get; set; }
    }

}
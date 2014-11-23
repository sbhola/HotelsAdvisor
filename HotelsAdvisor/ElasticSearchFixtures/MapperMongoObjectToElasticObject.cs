using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchFixtures
{
    public static class MapperMongoObjectToElasticObject
    {
        public static ElasticSearchFixtures.HotelElastic ToElasticContract(this HotelAdvisor.BLL.Model.Hotel obj)
        {
            return obj == null ? null :
                new HotelElastic
                {
                    Address = obj.Address,
                    City = obj.City,
                    Country = obj.Country,
                    Id = obj.Id.ToString(),
                    Latitude = obj.Latitude,
                    Longitude = obj.Longitude,
                    Name = obj.Name,
                };
        }
    }
}

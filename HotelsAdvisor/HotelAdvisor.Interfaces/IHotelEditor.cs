
﻿using HotelAdvisor.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdvisor.Interfaces
{
    public interface IHotelEditor
    {
        bool DeleteReview(string reviewId);
        bool UpdateReview(string hotelId, Review review);
    }
}

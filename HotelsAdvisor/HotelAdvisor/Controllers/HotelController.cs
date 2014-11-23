using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HotelsAdvisor.HotelsAdvisorService.Proxy;
using HotelsAdvisor.Models;
using Review = HotelsAdvisor.Models.Review;
using AutoMapper;

namespace HotelsAdvisor.Controllers
{
    public class HotelController : Controller
    {
        private static List<string> _hotelIds = new List<string>();
        //
        // GET: /Hotel/
        public ActionResult Index()
        {
            var homePageModel = new HomePageModel();
            //homePageModel.Load();
            //return View(homePageModel);
            var mappedHotelsList = new List<Models.Hotel>();
            Mapper.CreateMap<HotelsAdvisorService.Proxy.Review, Models.Review>();
            Mapper.CreateMap<HotelsAdvisorService.Proxy.Hotel, Models.Hotel>();

            using (var client = new HotelsAdvisorClient())
            {
                var hotelList = client.GetTopHotels(6);
                mappedHotelsList.AddRange(hotelList.Select(Mapper.Map<HotelsAdvisorService.Proxy.Hotel, HotelsAdvisor.Models.Hotel>));
                //var mappedHotelsList = Mapper.Map<List<HotelsAdvisorService.Proxy.Hotel>, List<HotelsAdvisor.Models.Hotel>>(hotelList);
                homePageModel.TopHotels = mappedHotelsList;
                return View(homePageModel);
            }

        }

        public ActionResult CustomLogin()
        {
            return View();
        }

        public ActionResult HotelsListing()
        {
            //Get list of hotels from id
            //creating dummy list of hotels

            //var hotelsId = new List<string>
            //    {
            //        "54449b653c496210940dad09",
            //        "54449bb63c49621d9cab0bf8",
            //        "54449bdd3c4962222c69f939",
            //        "54449bdf3c4963222ca67e46",
            //        "54449bb63c49621d9cab0bf8"
            //    };
            if (_hotelIds.Count == 0)
                return View("Error");

            var hotels = new List<Models.HotelModelForIntermediatePage>();
            Mapper.CreateMap<HotelsAdvisorService.Proxy.HotelModelForIntermediatePage, Models.HotelModelForIntermediatePage>();
            using (var client = new HotelsAdvisorClient())
            {
                var list = client.FetchHotelsByIdList(_hotelIds.ToArray());
                hotels.AddRange(list.Select(Mapper.Map<HotelsAdvisorService.Proxy.HotelModelForIntermediatePage, HotelsAdvisor.Models.HotelModelForIntermediatePage>));
                return View(hotels.ToList());
            }
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        //
        // GET: /Hotel/Details/5

        public ActionResult Details(string hotelId)
        {
            //= "544f6337d7e32110c4377fb6"
            Mapper.CreateMap<HotelsAdvisorService.Proxy.Review, Models.Review>();
            Mapper.CreateMap<HotelsAdvisorService.Proxy.Hotel, Models.Hotel>();

            using (var client = new HotelsAdvisorClient())
            {
                var hotel = client.GetHotelById(hotelId);
                var mappedHotel = Mapper.Map<HotelsAdvisorService.Proxy.Hotel, HotelsAdvisor.Models.Hotel>(hotel);
                return View(mappedHotel);
            }
        }

        [HttpPost]
        public ActionResult ListHotels(HomePageModel homePageModel)
        {
            if (homePageModel.SearchResult.Category == null)
                return RedirectToAction("Index", "Home");

            if (homePageModel.SearchResult.Category.Equals("Hotel"))
            {
                //RedirectToAction("Details", homePageModel.SearchResult.Id);
                return RedirectToAction("Details", "Hotel", new { hotelId = homePageModel.SearchResult.Id });
            }
            else
            {
                var elasticObj = new ElasticSearch.ElasticSearch();
                var localHotelIds = elasticObj.FetchHotelIds(homePageModel.SearchResult.SearchResultLine1.Split(',')[0], homePageModel.SearchResult.SearchResultLine3);
                _hotelIds.Clear();
                foreach (var hotelId in localHotelIds)
                    _hotelIds.Add(hotelId);
                return RedirectToAction("HotelsListing", "Hotel");
            }

            //try
            //{
            //     TODO: Add update logic here
            //    string diaplayResult = Convert.ToString(collection["SearchResult.DisplayResult"]);
            //    string category = Convert.ToString(collection["SearchResult.Category"]);
            //    string searchResultLine1 = Convert.ToString(collection["SearchResult.SearchResultLine1"]);
            //    string searchResultLine2 = Convert.ToString(collection["SearchResult.SearchResultLine2"]);
            //    string searchResultLine3 = Convert.ToString(collection["SearchResult.SearchResultLine3"]);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        [Authorize]
        public ActionResult AddReview(string hotelId)
        {
            var client = new HotelsAdvisorClient();

            var hotel = client.GetHotelById(hotelId);

            Mapper.CreateMap<HotelsAdvisorService.Proxy.Review, Models.Review>();
            Mapper.CreateMap<HotelsAdvisorService.Proxy.Hotel, Models.Hotel>();

            var mappedHotel = Mapper.Map<HotelsAdvisorService.Proxy.Hotel, HotelsAdvisor.Models.Hotel>(hotel);
            var viewModel = new HotelReview
                {
                    Hotel = mappedHotel,
                    Review = new Review
                        {
                            HotelId = mappedHotel.Id,

                        }
                };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(Review review)
        {
            var result = review;

            result.UtcTimeSubmitted = DateTime.UtcNow;

            result.UserName = User.Identity.Name;

            Mapper.CreateMap<Models.Review, HotelsAdvisorService.Proxy.Review>();
            var mappedReview = Mapper.Map<HotelsAdvisor.Models.Review, HotelsAdvisorService.Proxy.Review>(review);

            try
            {
                //call AddReview() of service
                using (var client = new HotelsAdvisorClient())
                {
                    client.AddReview(mappedReview.HotelId, mappedReview);
                }
                return RedirectToAction("Details", "Hotel", new { hotelId = mappedReview.HotelId });
            }
            catch
            {
                return RedirectToAction("Details", "Hotel", new { hotelId = mappedReview.HotelId });
            }
        }


        //
        // GET: /Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hotel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Hotel/Delete/5
        [Authorize]
        public ActionResult Delete(string hotelId, string reviewId)
        {
            Mapper.CreateMap<HotelsAdvisorService.Proxy.Review, Models.Review>();
            Mapper.CreateMap<HotelsAdvisorService.Proxy.Hotel, Models.Hotel>();

            using (var client = new HotelsAdvisorClient())
            {
                var deleteResult = client.DeleteReview(reviewId);

                var hotel = client.GetHotelById(hotelId);
                var mappedHotel = Mapper.Map<HotelsAdvisorService.Proxy.Hotel, HotelsAdvisor.Models.Hotel>(hotel);
                return View("Details", mappedHotel);

                //return View("Details", hotelId);
                //return RedirectToAction("Details", hotelId);
                //return View();
                //RedirectToAction("Details", hotelId);
            }
            //return View();
        }

        //
        // POST: /Hotel/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetListForAutocomplete(string term)
        {

            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new
                {
                    label = "You have to enter Hotel name or Location"
                },
              JsonRequestBehavior.AllowGet);
            }
            var autocompleteDataProvider = new AutocompleteData.AutocompleteDataProvider();
            AutocompleteData.AutocompleteSearchObject[] matching = null;
            matching = autocompleteDataProvider.getMatchingData(term.Trim());
            if (matching.Length == 0)
                return Json(new
                {
                    label = "No results found"
                },
               JsonRequestBehavior.AllowGet);

            return Json(matching.Select(m => new
            {
                value = (string.IsNullOrWhiteSpace(m.SearchResultLine1) ? "" : m.SearchResultLine1) +
                      (string.IsNullOrWhiteSpace(m.SearchResultLine2) ? "" : ("," + m.SearchResultLine2)) +
                      (string.IsNullOrWhiteSpace(m.SearchResultLine3) ? "" : ("," + m.SearchResultLine3)),
                label = m.SearchResultLine1,
                Id = m.Id,
                Category = m.Category,
                SearchResultLine1 = m.SearchResultLine1,
                SearchResultLine2 = m.SearchResultLine2,
                SearchResultLine3 = m.SearchResultLine3
            }),

            JsonRequestBehavior.AllowGet);
        }
    }
}


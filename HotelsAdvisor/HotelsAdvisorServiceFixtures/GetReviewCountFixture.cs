//using System.ServiceModel;
//using HotelsAdvisorServiceFixtures.HotelsAdvisorService.Proxy;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace HotelsAdvisorServiceFixtures
//{
//    [TestClass]
//    public class GetReviewCountFixture
//    {

//        [TestMethod]
//        public void TestForGetReviewCountWithNullHotelIdShouldThrow()
//        {

//            using (var client = new HotelsAdvisorClient())
//            {
//                const string id = null;
//                try
//                {
//                    client.GetReviewCount(id);
//                }
//                catch (FaultException<CustomFaults> fault)
//                {

//                    Assert.AreEqual(100, fault.Detail.FaultCode);
//                }
//            }
//        }

//        [TestMethod]
//        public void TestForGetReviewCountWithInvalidHotelIdShouldThrow()
//        {
//            using (var client = new HotelsAdvisorClient())
//            {
//                const string id = "asasew54";
//                try
//                {
//                    client.GetReviewCount(id);
//                }
//                catch (FaultException<CustomFaults> fault)
//                {

//                    Assert.AreEqual(104, fault.Detail.FaultCode);
//                }
//            }
//        }

//        [TestMethod]
//        public void TestForGetReviewCountWithValidHotelIdShouldRespondCorrect()
//        {
//            using (var client = new HotelsAdvisorClient())
//            {
//                const string id = "543f4be93c496418e82229b2";

//                var count = client.GetReviewCount(id);

//                Assert.AreEqual(client.GetReviewCount(id), count);

//            }
//        }
//    }
//}

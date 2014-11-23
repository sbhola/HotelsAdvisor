//using System.ServiceModel;
//using HotelsAdvisorServiceFixtures.HotelsAdvisorService.Proxy;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace HotelsAdvisorServiceFixtures
//{
//    [TestClass]
//    public class ReviewIdGeneratorFixture
//    {
//        [TestMethod]
//        public void TestForReviewIdGeneratorWithNullHotelIdShouldThrow()
//        {
//            using (var client = new HotelsAdvisorClient())
//            {
//                const string id = null;
//                try
//                {
//                    client.ReviewIdGenerator(id);
//                }
//                catch (FaultException<CustomFaults> fault)
//                {

//                    Assert.AreEqual(100, fault.Detail.FaultCode);
//                }
//            }
//        }

//        [TestMethod]
//        public void TestForReviewIdGeneratorWithInvalidHotelIdShouldThrow()
//        {
//            using (var client = new HotelsAdvisorClient())
//            {
//                const string id = "dsdsadf52";
//                try
//                {
//                    client.ReviewIdGenerator(id);
//                }
//                catch (FaultException<CustomFaults> fault)
//                {

//                    Assert.AreEqual(105, fault.Detail.FaultCode);
//                }
//            }
//        }

//        [TestMethod]
//        public void TestForReviewIdGeneratorWithValidHotelIdShouldGenerateProperReviewId()
//        {
//            using (var client = new HotelsAdvisorClient())
//            {
//                const string id = "543f4be93c496418e82229b2";

//                var value = client.ReviewIdGenerator(id);

//                Assert.AreEqual(client.GetReviewCount(id)+1, value);

//            }
//        }
//    }
//}

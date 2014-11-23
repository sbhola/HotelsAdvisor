using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using HotelsAdvisorServiceFixtures.HotelsAdvisorService.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelsAdvisorServiceFixtures
{
    [TestClass]
    public class FetchHotelsByIdFixture
    {
        [TestMethod]
        public void TestForFetchHotelsByIdWithNullHotelIdListShouldThrow()
        {
            using (var client = new HotelsAdvisorClient())
            {
                try
                {
                    client.FetchHotelsByIdList(null);
                }
                catch (FaultException<CustomFaults> fault)
                {
                    Assert.AreEqual(107, fault.Detail.FaultCode);
                }
            }
        }


        [TestMethod]
        public void TestForFetchHotelsByIdWithNullHotelIdInListShouldThrow()
        {
            var list = new List<string> { "dfadsfdsaf", null, "dsafdsfsdfdsfewter2052" };
            using (var client = new HotelsAdvisorClient())
            {
                try
                {
                    client.FetchHotelsByIdList(list.ToArray());
                }
                catch (FaultException<CustomFaults> fault)
                {
                    Assert.AreEqual(107, fault.Detail.FaultCode);
                }

            }
        }

        [TestMethod]
        public void TestForFetchHotelsByIdWithValidHotelIdShouldRespondCorrect()
        {
            using (var client =new HotelsAdvisorClient())
            {
                var list = new List<string>
                {
                    "54449b653c496210940dad09",
                    "54449bb63c49621d9cab0bf8",
                    "54449bdd3c4962222c69f939",
                    "54449bdf3c4963222ca67e46"
                };

                var result = client.FetchHotelsByIdList(list.ToArray());
                Assert.AreEqual(4,result.Count());
            }
        }

    }
}

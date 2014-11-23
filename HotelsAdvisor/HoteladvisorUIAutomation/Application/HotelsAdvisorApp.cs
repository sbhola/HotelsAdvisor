using AppacitiveAutomationFramework;
using HoteladvisorUIAutomation.Pages;

namespace HoteladvisorUIAutomation.Application
{
    public class HotelsAdvisorApp:UIApplication
    {
        public HomePage HomePage
        {
            get { return InitializePage<HomePage>("HomeControls"); }
        }

        public RegisterPage RegisterPage
        {
            get { return InitializePage<RegisterPage>("RegisterControls"); }
        }

        public LoginPage LoginPage
        {
            get
            {
                return InitializePage<LoginPage>("LoginControls");
            }
        }

        public DetailsPage DetailsPage
        {
            get
            {
                return InitializePage<DetailsPage>("DetailsControls");
            }
        }

        public HotelListingPage HotelListingPage
        {
            get { return InitializePage<HotelListingPage>("HotelListingControls"); }
        }

        public AddReviewPage AddReviewPage
        {
            get { return InitializePage<AddReviewPage>("AddReviewControls"); }
        }
    }
}

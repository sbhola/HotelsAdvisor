
using System.Configuration;

namespace HoteladvisorUIAutomation.Configuration
{
    public static class ApplicationSettings
    {
        public static string Url
        {
            get { return ConfigurationManager.AppSettings["application.url"] ?? "http://192.168.2.105/"; }
        }

        public static string HomePageUrl
        {
            get
            {
                return "http://192.168.2.105/";
            }
        }
        public static string LoginUrl
        {
            get
            {
                return "http://192.168.2.105/";
            }
        }

        public static string DetailsUrl
        {
            get
            {
                return "http://192.168.2.105/Hotel/Details?hotelId=545caf47d7e3092014261d7f";
            }
        }
      



        //public static class WebUser
        //{
        //    public static string Username
        //    {
        //        get { return ConfigurationManager.AppSettings["application.webuser.username"]; }
        //    }

        //    public static string Password
        //    {
        //        get { return ConfigurationManager.AppSettings["application.webuser.password"]; }
        //    }

        //}

        public static class TimeOut
        {
            public static int Safe { get { return 10; } }
            public static int Slow { get { return 8; } }
            public static int Fast { get { return 5; } }
            public static int SuperFast { get { return 3; } }



        }


      
       
    }
}

using System;
using System.Configuration;

namespace SearchFight.NetCoreApp
{
    public static class AppConfig
    {
        public static string x = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;

        public static String GENERIC_END_POINT = ConfigurationManager.AppSettings["GENERIC_END_POINT"].ToString();
        public static String GENERIC_SEARCH_ACTION = ConfigurationManager.AppSettings["GENERIC_SEARCH_ACTION"].ToString();
        public static String GENERIC_AUTHORIZATION_KEY = ConfigurationManager.AppSettings["GENERIC_AUTHORIZATION_KEY"].ToString();

        public static String GOOGLE_END_POINT = ConfigurationManager.AppSettings["GOOGLE_END_POINT"].ToString();
        public static String GOOGLE_SEARCH_ACTION = ConfigurationManager.AppSettings["GOOGLE_SEARCH_ACTION"].ToString();
        public static String GOOGLE_KEY = ConfigurationManager.AppSettings["GOOGLE_KEY"].ToString();
        public static String GOOGLE_CX = ConfigurationManager.AppSettings["GOOGLE_CX"].ToString();

        public static String BING_END_POINT = ConfigurationManager.AppSettings["BING_END_POINT"].ToString();
        public static String BING_SEARCH_ACTION = ConfigurationManager.AppSettings["BING_SEARCH_ACTION"].ToString();
        public static String BING_OCP_APIM_SUBSCRIPTION_KEY = ConfigurationManager.AppSettings["BING_OCP_APIM_SUBSCRIPTION_KEY"].ToString();
    }
}

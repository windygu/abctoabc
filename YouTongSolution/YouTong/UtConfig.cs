using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace YouTong
{
    public class UtConfig
    {
        static UtConfig()
        {
            FamilyMediaChannelID = new Guid(ConfigurationManager.AppSettings["FamilyMedia_ChannelID"]);
            WorksChannelID = new Guid(ConfigurationManager.AppSettings["Works_ChannelID"]);
            BlogChannelID = new Guid(ConfigurationManager.AppSettings["Blog_ChannelID"]);

            DouXiuChannelID = new Guid(ConfigurationManager.AppSettings["DouXiu_ChannelID"]);
            HuoDongChannelID = new Guid(ConfigurationManager.AppSettings["HuoDong_ChannelID"]);

            StarChildID = new Guid(ConfigurationManager.AppSettings["StarChildID"]);

            DisneyExpoActivityID = new Guid(ConfigurationManager.AppSettings["DisneyExpo_ActivityID"]);

            DrawingChannelID = new Guid(ConfigurationManager.AppSettings["DrawingChannelID"]);
            CameraChannelID = new Guid(ConfigurationManager.AppSettings["CameraChannelID"]);
            FilmChannelID = new Guid(ConfigurationManager.AppSettings["FilmChannelID"]);


            Domain = ConfigurationManager.AppSettings["Domain"];
        }

        public static Guid FamilyMediaChannelID;
        public static Guid WorksChannelID;
        public static Guid BlogChannelID;

        public static Guid DouXiuChannelID;
        public static Guid HuoDongChannelID;

        public static Guid StarChildID;

        public static Guid DisneyExpoActivityID;

        public static String Domain = "no1child.com";

        public static String SessionKeyPrefix = "ut_";
        public static String CookieKeyUserName = "ut_abc";
        public static String CookieKeyPassword = "ut_efg";
        public static String CookieKeyClientUserName = "ut_xyz";

        public static String SessionKey_User = SessionKeyPrefix + "User";

        public static Guid DrawingChannelID;
        public static Guid CameraChannelID;
        public static Guid FilmChannelID;
    }
}

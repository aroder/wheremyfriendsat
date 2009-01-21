using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WhereMyFriendsAt
{
    public static class Settings
    {
        public static readonly string FacebookApiKey = ConfigurationManager.AppSettings["FacebookApiKey"];
        public static readonly string FacebookApiSecret = ConfigurationManager.AppSettings["FacebookApiSecret"];
        public static readonly string FacebookApiApplicationId = ConfigurationManager.AppSettings["FacebookApiApplicationId"];
        public static readonly string FacebookLoginPageUrl = string.Format(@"http://www.facebook.com/login.php?api_key={0}&v=1.0", FacebookApiKey);
    }
}

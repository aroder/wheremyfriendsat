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
    public static class Constants
    {
        public static class Keys
        {
            public const string FACEBOOK_USER_SESSION_KEY = "FacebookSessionKey";
            public const string FACEBOOK_USER_SESSION_COOKIE_KEY = "FacebookSessionCookieKey";
            public const string FACEBOOK_USER_ID_KEY = "FacebookUserIdKey";
            public const string FACEBOOK_USER_SESSION_EXPIRES = "FacebookSessionExpires";
        }
        public static class QueryStringKeys
        {
            public const string FACEBOOK_AUTH_TOKEN = "auth_token";
        }
    }
}

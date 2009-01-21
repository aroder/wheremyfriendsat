using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhereMyFriendsAt.Extensions;

namespace WhereMyFriendsAt.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            facebook.Components.FacebookService fbSvc = new facebook.Components.FacebookService();
            fbSvc.ApplicationKey = Settings.FacebookApiKey;
            fbSvc.Secret = Settings.FacebookApiSecret;
            fbSvc.IsDesktopApplication = false;

           
            // if this cookie is set, the user should have a session
            if (null != Request.Cookies[Constants.Keys.FACEBOOK_USER_SESSION_COOKIE_KEY])
            {
                HttpCookie cookie = Request.Cookies[Constants.Keys.FACEBOOK_USER_SESSION_COOKIE_KEY];
                fbSvc.SessionKey = cookie[Constants.Keys.FACEBOOK_USER_SESSION_KEY];
                fbSvc.uid = long.Parse(cookie[Constants.Keys.FACEBOOK_USER_ID_KEY]);
            }

            // when the user uses the facebook login page, the redirect back here will have the auth_token in the query params
            else if (!string.IsNullOrEmpty(Request.QueryString[Constants.QueryStringKeys.FACEBOOK_AUTH_TOKEN]))
            {
                fbSvc.CreateSession(Request.QueryString[Constants.QueryStringKeys.FACEBOOK_AUTH_TOKEN]);
                HttpCookie cookie = new HttpCookie(Constants.Keys.FACEBOOK_USER_SESSION_COOKIE_KEY);
                cookie[Constants.Keys.FACEBOOK_USER_SESSION_KEY] = fbSvc.SessionKey;
                cookie[Constants.Keys.FACEBOOK_USER_ID_KEY] = fbSvc.uid.ToString();
                cookie[Constants.Keys.FACEBOOK_USER_SESSION_EXPIRES] = fbSvc.SessionExpires.ToString();

                // if the facebook session never expires, set our cookie to expire
                // if the facebook session does expire, not setting the cookie expiry will wipe
                // cookie clean on browser close
                if (!fbSvc.SessionExpires) cookie.Expires = DateTime.Now.AddMinutes(60);

                Response.Cookies.Add(cookie);
            }
            else
            {
                Response.Redirect(Settings.FacebookLoginPageUrl, true);
            }

            return View("Facebook1", fbSvc.friends.getUserObjects());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WhereMyFriendsAt
{
    public partial class _Default : Page
    {
        public void Page_Load(object sender, System.EventArgs e)
        {
            Response.Redirect("~/Map.mvc/MapTest");
        }
    }
}

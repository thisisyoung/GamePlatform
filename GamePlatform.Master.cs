using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GamePlatform.Entities;

namespace GamePlatform
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        
        public GuestInfo Guest { get; set; }
        public OnlineGuestsInfo GuestsInfo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string guestId = this.Context.Items["GuestId"].ToString();
            GuestsInfo = Application["OnlineGuestsInfo"] as OnlineGuestsInfo;
            Guest = GuestsInfo.GetGuestByGuestId(guestId);
        }
    }
}

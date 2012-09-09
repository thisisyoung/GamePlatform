using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamePlatform.Entities;
using GamePlatform.Action;

namespace GamePlatform
{
    /// <summary>
    /// Summary description for NewGuestHandler
    /// </summary>
    public class NewGuestHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            OnlineGuestsInfo guestsInfo = context.Application["OnlineGuestsInfo"] as OnlineGuestsInfo;
            GuestInfo newGuest = GuestAction.CreateNewGuest();
            guestsInfo.GuestInfoList.Add(newGuest);
            HttpCookie guestIdCookie = new HttpCookie("GuestId", newGuest.GuestId);
            context.Response.Cookies.Add(guestIdCookie);
            context.Items.Add("GuestId", newGuest.GuestId);
            context.Response.Redirect("/Home.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
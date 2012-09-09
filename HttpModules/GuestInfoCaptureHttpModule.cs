using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamePlatform.Entities;
using System.IO;
using GamePlatform.Utilities;

namespace GamePlatform.HttpModules
{
    public class GuestInfoCaptureHttpModule : IHttpModule
    {


        public GuestInfoCaptureHttpModule()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {

            app.BeginRequest += new EventHandler(OnBeginRequest);
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {


            HttpApplication app = sender as HttpApplication;
            string filename = Path.GetFileName(app.Request.PhysicalPath);
            if (filename.LastIndexOf(".aspx") == filename.Length - 5)
            {

                HttpCookie guestIdCookie = app.Request.Cookies["GuestId"];
                OnlineGuestsInfo guestsInfo = app.Application["OnlineGuestsInfo"] as OnlineGuestsInfo;
                if (guestIdCookie == null)
                {
                    string newId = GPUtilities.GetNewGUID();
                    guestIdCookie = new HttpCookie("GuestId", newId);
                    app.Response.Cookies.Add(guestIdCookie);
                    GuestInfo newGuest = new GuestInfo();
                    newGuest.GuestId = newId;
                    newGuest.GuestName = newGuest.GuestId.Substring(0, 8);
                    newGuest.LastAliveTime = DateTime.Now;
                    guestsInfo.GuestInfoList.Add(newGuest);
                }
                else
                {
                    GuestInfo guest = guestsInfo.GetGuestByGuestId(guestIdCookie.Value);
                    guest.LastAliveTime = DateTime.Now;
                }
            }
        }

    }
}
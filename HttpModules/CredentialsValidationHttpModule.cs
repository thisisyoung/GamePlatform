using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamePlatform.Entities;
using System.IO;

namespace GamePlatform.HttpModules
{
    public class CredentialsValidationHttpModule : IHttpModule
    {
        public CredentialsValidationHttpModule()
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
            string requestPath = Path.GetFileName(app.Request.Path);
            
            if (requestPath.EndsWith(".aspx"))
            {
                bool isNewGuest = false;
                HttpCookie guestIdCookie = app.Request.Cookies["GuestId"];
                OnlineGuestsInfo guestsInfo = app.Application["OnlineGuestsInfo"] as OnlineGuestsInfo;
                if (guestIdCookie == null)
                {
                    isNewGuest = true;
                }
                else if (!guestsInfo.IsGuestExistsInList(guestIdCookie.Value))
                {
                    isNewGuest = true;
                }
                else
                {
                    app.Context.Items.Add("GuestId", guestIdCookie.Value);
                }

                if (!requestPath.Contains("NewGuestHandler.ashx") && isNewGuest)
                {
                    app.Response.Redirect("/NewGuestHandler.ashx");
                }

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamePlatform.Entities;
using GamePlatform.Utilities;
namespace GamePlatform.Action
{
    public class GuestAction
    {
        public GuestAction()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static GuestInfo CreateNewGuest()
        {
            string newId = GPUtilities.GetNewGUID();
            GuestInfo newGuest = new GuestInfo();
            newGuest.GuestId = newId;
            newGuest.GuestName = newGuest.GuestId.Substring(0, 8);
            newGuest.LastAliveTime = DateTime.Now;

            return newGuest;
        }
    }
}
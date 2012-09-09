using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamePlatform.Entities
{
    public class OnlineGuestsInfo
    {
        private static OnlineGuestsInfo guestsInfo = null;

        public GuestInfoList GuestInfoList { get; set; }

        public static OnlineGuestsInfo GetInstance()
        {

            if (guestsInfo == null)
            {
                guestsInfo = new OnlineGuestsInfo();
            }

            return guestsInfo;
        }

        private OnlineGuestsInfo()
        {
            GuestInfoList = new GuestInfoList();
            //
            // TODO: Add constructor logic here
            //
        }

        public GuestInfo GetGuestByGuestId(string guestId)
        {
            return GuestInfoList.Single(guest => guest.GuestId.Equals(guestId));
        }

        public bool IsGuestExistsInList(string guestId)
        {
            return GuestInfoList.Any(guest => guest.GuestId.Equals(guestId));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamePlatform.Entities;

namespace GamePlatform.Action
{
    public class ServerMessageDistributor
    {
        public ServerMessageAsyncResult Result { get; private set; }
        private HttpContext _context;
        private AsyncCallback _callback;

        public ServerMessageDistributor(HttpContext context, AsyncCallback callback)
        {
            Result = new ServerMessageAsyncResult();
            _context = context;
            _callback = callback;
        }

        public void GetTotalGuestsCount(GuestInfoList guestInfoList)
        {
            guestInfoList.Changed += new ChangedEventHandler(DistributeNewTotalGuestCount);
        }

        void DistributeNewTotalGuestCount(object sender, EventArgs e)
        {
            try
            {
                _context.Response.Write((sender as GuestInfoList).Count.ToString());
                Result.IsCompleted = true;
                _callback(Result);
            }
            catch (Exception)
            {

            }
            
        }

        public void GetServerMessage()
        {

        }
    }
}
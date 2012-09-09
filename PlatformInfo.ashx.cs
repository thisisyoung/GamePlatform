using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamePlatform.Action;
using GamePlatform.Entities;

namespace GamePlatform
{
    /// <summary>
    /// Summary description for PlatformInfo
    /// </summary>
    public class PlatformInfo : IHttpAsyncHandler
    {

        class MyAsyncResult : IAsyncResult
        {
            public object AsyncState
            {
                get { throw new NotImplementedException(); }
            }

            public System.Threading.WaitHandle AsyncWaitHandle
            {
                get { throw new NotImplementedException(); }
            }

            public bool CompletedSynchronously
            {
                get { return false; }
            }

            public bool IsCompleted
            {
                get { return true; }
            }
        }

        public void ProcessRequest(HttpContext context)
        {
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            ServerMessageDistributor msgDistributor = new ServerMessageDistributor(context, cb);
            msgDistributor.GetTotalGuestsCount((context.Application["OnlineGuestsInfo"] as OnlineGuestsInfo).GuestInfoList);
            return msgDistributor.Result;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            HttpContext.Current.Response.Write("aaaaa");
        }
    }
}
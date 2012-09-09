using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamePlatform.Entities
{
    public class ServerMessageAsyncResult:IAsyncResult
    {
        public string message { get; set; }

        private bool _isCompleted;

        public object AsyncState
        {
            get { return message; }
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { return null; }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }
    }
}
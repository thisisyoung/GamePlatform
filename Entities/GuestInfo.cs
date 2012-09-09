using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamePlatform.Entities
{
    public class GuestInfo
    {
        public string GuestId { get; set; }
        public string GuestName { get; set; }
        public DateTime LastAliveTime { get; set; }

        public GuestInfo()
        {
        }
    }
}
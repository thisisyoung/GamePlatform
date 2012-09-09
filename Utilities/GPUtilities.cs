using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamePlatform.Utilities
{
    public class GPUtilities
    {

        public GPUtilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string GetNewGUID()
        {
            Guid id = Guid.NewGuid();
            return id.ToString();
        }
    }
}
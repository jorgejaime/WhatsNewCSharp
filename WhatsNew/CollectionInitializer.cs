using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNew
{
    public static class CollectionInitializer
    {
       
            public static void Add(this Dictionary<int, string> dic, int no)
            {
                dic.Add(no, "Number " + no.ToString());
            }
        
    }
}

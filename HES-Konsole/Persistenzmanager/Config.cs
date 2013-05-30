using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistenzmanager
{
    public static class Config
    {
        public static String cs()
        {
            //return "Server=db4free.net;Uid=hesadmin;Pwd=damase;Database=hesdb;";
            return "Server=localhost;Uid=root;Pwd=root;Database=hesdb;";
        }
    }
}

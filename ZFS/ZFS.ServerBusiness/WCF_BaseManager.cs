using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.ServerBusiness
{
    public class WCF_BaseManager<T> where T : class, new()
    {
        protected ServiceReference.BaseServiceClient Server;
        public WCF_BaseManager()
        {
            if (Server == null)
            {
                Server = new ServiceReference.BaseServiceClient();
            }
        }
    }
}

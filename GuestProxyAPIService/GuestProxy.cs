using System;

namespace GuestProxyAPIService
{
    public class GuestProxy
    {
        public Kubeconfig[] kubeconfigs { get; set; }
        public Hybridconnectionconfig hybridConnectionConfig { get; set; }
        public class Hybridconnectionconfig
        {
            public string relay { get; set; }
            public string hybridConnectionName { get; set; }
            public string token { get; set; }
            public int expiry { get; set; }
        }

        public class Kubeconfig
        {
            public string name { get; set; }
            public string value { get; set; }
        }
    }
}

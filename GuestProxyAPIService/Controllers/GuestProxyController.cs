using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GuestProxyAPIService.Controllers
{
    [ApiController]
    [Route("subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Kubernetes/connectedClusters/{cluster}/register")]
    public class GuestProxyController : ControllerBase
    {

        private readonly ILogger<GuestProxyController> _logger;

        public GuestProxyController(ILogger<GuestProxyController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<string> Post(GuestProxy obj, string subid, string rg, string cluster)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(string.Format("http://localhost:47010/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Kubernetes/connectedClusters/{2}/register", subid, rg, cluster), httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responsebody = await response.Content.ReadAsStringAsync();
                return responsebody;
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
    }
}

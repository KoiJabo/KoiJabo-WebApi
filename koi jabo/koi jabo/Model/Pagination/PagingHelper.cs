using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace koi_jabo_models.Models.Pagination
{
    public class PagingHelper
    {
        UrlHelper urlHelper;
        public PagingHelper(HttpRequestMessage requestMessage)
        {
            urlHelper = new UrlHelper(requestMessage);
        }

        internal string GeneratePageUrl(string route, long page, long pageSize, Dictionary<string, object> otherParams = null)
        {
            Dictionary<string, object> routeParams = new Dictionary<string, object>();
            routeParams.Add("page", page.ToString());
            routeParams.Add("pageSize", pageSize.ToString());

            foreach (var param in otherParams)
            {

                if (param.Key == "value")
                {
                    if (param.Value != "")
                    {
                        routeParams.Add("value", param.Value);
                    }
                }

                else if (param.Key == "costupperlimit")
                {
                    routeParams.Add("costupperlimit", param.Value);
                }
                else if (param.Key == "costlowerlimit")
                {
                    routeParams.Add("costlowerlimit", param.Value);
                }
                else if (param.Key == "lat")
                {
                    routeParams.Add("lat", param.Value);
                }
                else if (param.Key == "lon")
                {
                    routeParams.Add("lon", param.Value);
                }
                else if (param.Key == "distance")
                {
                    routeParams.Add("distance", param.Value);
                }
            }

            return urlHelper.Link(route, routeParams);
        }
    }
}

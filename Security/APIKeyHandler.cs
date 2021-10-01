using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Programming.API.Security
{
    public class APIKeyHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage Request, CancellationToken C)
        {
            var QueryString = Request.RequestUri.ParseQueryString();
            var ApiKey = QueryString["apiKey"]; //ApiKey'i QueryString'den alıyoruz. Bu şekilde olduğunda arama çubuğuna ApiKey= yazıp Api anahtarını girmemiz gerekir.

            //var ApiKey = Request.Headers.GetValues("ApiKey").FirstOrDefault(); //ApiKey'i Request Header'dan alıyoruz. Bu şekilde olduğunda ise Api anahtarını Fiddler ile arama yaparken Request Header'ın apiKey property'sinin içerisine yazacağız.

            UsersDAL UserDAL = new UsersDAL();
            var User = UserDAL.GetUserByApiKey(ApiKey);

            if (User != null)
            {
                var Principal = new ClaimsPrincipal(new GenericIdentity(User.Name,"APIKey")); //Böyle bir kullanıcı varsa bir principal objesi oluştur ve bu kullanıcıya ata.
                HttpContext.Current.User = Principal;
            }

            return base.SendAsync(Request, C);
        }
    }
}

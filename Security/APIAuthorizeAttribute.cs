using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Programming.API.Security
{
    public class APIAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var ActionRoles = Roles;
            var UserName = HttpContext.Current.User.Identity.Name;
            UsersDAL UserDAL = new UsersDAL();
            var User = UserDAL.GetUsersByName(UserName);

            if (User != null && ActionRoles.Contains(User.Role))
            {

            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            //base.OnAuthorization(actionContext);
        }
    }
}

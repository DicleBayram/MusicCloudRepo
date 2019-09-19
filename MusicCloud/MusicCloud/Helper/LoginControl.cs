using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusicCloud.Helper
{
    public class LoginControl : AuthorizeAttribute
    {
        private MusicCloudEntities db = new MusicCloudEntities();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["UserName"] != null)
            {
                string userName = httpContext.Session["UserName"].ToString();

                var user = db.User.Where(x => x.UserName == userName).FirstOrDefault();

                var roles = Roles.Split(',');

                if (user.UserTypeId == 1)
                {
                    if (roles.Contains("admin"))
                    {
                        return true;
                    }
                }

                else if (user.UserTypeId == 2)
                {
                    if (roles.Contains("user"))
                    {
                        return true;
                    }
                }
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}
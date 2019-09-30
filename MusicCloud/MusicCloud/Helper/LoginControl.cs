using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MusicCloud.Helper.Constants;

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
                    if (roles.Contains(UserRoles.Admin))
                    {
                        return true;
                    }
                }

                else if (user.UserTypeId == 2)
                {
                    if (roles.Contains(UserRoles.User))
                    {
                        return true;
                    }
                }
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}
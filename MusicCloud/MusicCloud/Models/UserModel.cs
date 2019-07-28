using MusicCloud.Binders;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicCloud.Models
{
    public class UserModel
    {
        private MusicCloudEntities db = new MusicCloudEntities();

        public int Id { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        public UserModel GetUserByUsername(string userName)
        {
            User dbUser = db.User.Where(u => u.UserName == userName).FirstOrDefault();
            UserBinder binder = new UserBinder();
            UserModel userModel = binder.Bind(dbUser);        
            return userModel;
        }




    }
}
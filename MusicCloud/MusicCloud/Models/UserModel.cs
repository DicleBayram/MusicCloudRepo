﻿using MusicCloud.Binders;
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
        [DataType(DataType.Password)]
        [Display(Name = "Re-Password")]
        public string RePassword { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "User Type")]
        public int UserTypeId { get; set; }
        [Display(Name = "User Type")]
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
using MusicCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCloud.Binders
{
    public class UserBinder
    {
        public User Bind(UserModel userModel)
        {
            User user = new User();
            try
            {
                user.Id = userModel.Id;
                user.Password = userModel.Password;
                user.UserName = userModel.UserName;
                user.UserTypeId = userModel.UserTypeId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return user;
        }

        public UserModel Bind(User user)
        {
            UserModel userModel = new UserModel();
            if (user != null)
            {
                try
                {
                    userModel.Id = user.Id;
                    userModel.Password = user.Password;
                    userModel.UserName = user.UserName;
                    userModel.UserTypeId = user.UserTypeId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }

            return userModel;
        }

        public ICollection<UserModel> Bind(ICollection<User> user)
        {
            ICollection<UserModel> userModelList = new List<UserModel>();

            try
            {
                foreach (User item in user)
                {
                    UserModel userModel = new UserModel();
                    userModel.UserName = item.UserName;
                    userModel.Password = item.Password;
                    userModel.UserTypeId = item.UserType.Id;
                    userModel.UserTypeName = item.UserType.UserTypeCode;
                    userModelList.Add(userModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return userModelList;
        }
    }
}
using MusicCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCloud.Binders
{
    public class UserTypeBinder
    {
        public UserType Bind(UserTypeModel userTypeModel)
        {
            UserType userType = new UserType();

            userType.Id = userTypeModel.Id;
            userType.UserTypeCode = userTypeModel.UserTypeCode;

            return userType;
        }

        public UserTypeModel Bind(UserType userType)
        {
            UserTypeModel userTypeModel = new UserTypeModel();

            userTypeModel.Id = userType.Id;
            userTypeModel.UserTypeCode = userType.UserTypeCode;

            return userTypeModel;
        }
    }
}
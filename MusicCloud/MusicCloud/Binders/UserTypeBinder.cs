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

        public ICollection<UserTypeModel> Bind(ICollection<UserType> userType)
        {
            ICollection<UserTypeModel> userTypeModelList = new List<UserTypeModel>();

            try
            {
                foreach (var item in userType)
                {
                    UserTypeModel userTypeModel = new UserTypeModel();
                    userTypeModel.Id = item.Id;
                    userTypeModel.UserTypeCode = item.UserTypeCode;
                    userTypeModelList.Add(userTypeModel);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
                        
            return userTypeModelList;
        }
    }
}
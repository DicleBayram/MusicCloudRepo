using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicCloud.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        

    }
}
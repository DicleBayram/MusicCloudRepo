//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicCloud
{
    using System;
    using System.Collections.Generic;
    
    public partial class Album
    {
        public Album()
        {
            this.Song = new HashSet<Song>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime UploadDate { get; set; }
        public int SingerId { get; set; }
    
        public virtual Singer Singer { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}
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
    
    public partial class Song
    {
        public Song()
        {
            this.ListenRecord = new HashSet<ListenRecord>();
        }
    
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int StyleId { get; set; }
        public string Name { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual ICollection<ListenRecord> ListenRecord { get; set; }
        public virtual Style Style { get; set; }
    }
}

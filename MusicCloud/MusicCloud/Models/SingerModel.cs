using System.Collections.Generic;

namespace MusicCloud.Models
{
    public class SingerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<AlbumModel> AlbumList { get; set; } // f.k olduğu tablo
    }
}
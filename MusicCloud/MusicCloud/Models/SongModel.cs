using System.Collections.Generic;

namespace MusicCloud.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int StyleId { get; set; }
        public string Name { get; set; }
        public string StyleName { get; set; }
        public string AlbumName { get; set; }

    }
}
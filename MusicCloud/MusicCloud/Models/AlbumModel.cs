using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicCloud.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Albüm Çıkış Tarihi")]
        public DateTime UploadDate { get; set; }
        public int SingerId { get; set; }

        //public virtual SingerModel Singer { get; set; }
        public virtual SingerModel SingerModel { get; set; }
        public virtual ICollection<SongModel> SongList { get; set; }
    }
}
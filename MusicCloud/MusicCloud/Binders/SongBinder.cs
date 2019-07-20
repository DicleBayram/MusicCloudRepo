using MusicCloud.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCloud.Binders
{
    public class SongBinder
    {
        public Song Bind(SongModel songModel)
        {
            Song song = new Song()
            {
                AlbumId = songModel.AlbumId,
                Id = songModel.Id,
                Name = songModel.Name,
                StyleId = songModel.StyleId
            };

            return song;
        }

        public ICollection<SongModel> Bind(ICollection<Song> song)
        {
            ICollection<SongModel> songModelList = new List<SongModel>();

            foreach (Song item in song)
            {
                SongModel songModel = new SongModel();
                songModel.Id = item.Id;
                songModel.Name = item.Name;
                songModel.AlbumId = item.AlbumId;
                songModel.AlbumName = item.Album.Name;
                songModel.StyleName = item.Style.Name;
                songModelList.Add(songModel);
            }

            return songModelList;
        }
    }
}
using MusicCloud.Models;
using System.Collections.Generic;

namespace MusicCloud.Binders
{
    public class AlbumBinder 
    {
        public Album Bind(AlbumModel albumModel)
        {
            Album album = new Album();

            album.Id = albumModel.Id;
            album.Name = albumModel.Name;
            album.SingerId = albumModel.SingerId;
            album.UploadDate = albumModel.UploadDate;

            return album;
        }

        public ICollection<AlbumModel> Bind(ICollection<Album> albumList)
        {
            ICollection<AlbumModel>  albumModelList = new List<AlbumModel>();

            foreach (Album item in albumList)
            {
                AlbumModel albumModel = new AlbumModel();
                albumModel.Id = item.Id;
                albumModel.Name = item.Name;
                albumModel.SingerId = item.SingerId;
                albumModel.UploadDate = item.UploadDate;
                albumModelList.Add(albumModel);
            }     

            return albumModelList;
        }
    }
}
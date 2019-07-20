using MusicCloud.Models;
using System.Collections.Generic;

namespace MusicCloud.Binders
{
    public class SingerBinder
    {
        public Singer Bind(SingerModel singerModel)
        {
            Singer singer = new Singer();

            singer.Id = singerModel.Id;
            singer.Name = singerModel.Name;

            return singer;
        }

        public ICollection<SingerModel> Bind(ICollection<Singer> singerList)
        {
            ICollection<SingerModel> singerModelList = new List<SingerModel>();

            foreach (Singer item in singerList)
            {
                SingerModel singerModel = new SingerModel();
                singerModel.Id = item.Id;
                singerModel.Name = item.Name;
                singerModelList.Add(singerModel);
            }

            return singerModelList;
        }
    }
}
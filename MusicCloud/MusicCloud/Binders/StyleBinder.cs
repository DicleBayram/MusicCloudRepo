using MusicCloud.Models;
using System.Collections.Generic;

namespace MusicCloud.Binders
{
    public class StyleBinder
    {
        public Style Bind(StyleModel styleModel)
        {
            Style style = new Style();

            style.Id = styleModel.Id;
            style.Name = styleModel.Name;

            return style;
        }

        public ICollection<StyleModel> Bind(ICollection<Style> style)
        {
            ICollection<StyleModel> styleModelList = new List<StyleModel>();

            foreach (Style item in style)
            {
                StyleModel styleModel = new StyleModel();
                styleModel.Id = item.Id;
                styleModel.Name = item.Name;
                styleModelList.Add(styleModel);
            }

            return styleModelList;
        }
    }    
}
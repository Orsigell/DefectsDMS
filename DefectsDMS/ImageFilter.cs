using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectsDMS
{
    public class ImageFilter
    {
        private Image image;

        public Image Image { get => image; set => image = value; }
        public Image BarGraph()//Гистограмма
        {
            return null;
        }
        public Image Filtration()//Фильтрация
        {
            return null;
        }
        public Image HighlightingBbackground()//Выделение фона
        {
            return null;
        }
        public Image HighlightingDefect()//Выделение дефета
        {
            return null;
        }
        public Image Segmentation()//Выделение дефета
        {
            return null;
        }
    }
}

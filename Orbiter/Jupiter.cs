using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Jupiter : IPlanet
    {
        public double Radius
        {
            get { return 5.20; }
        }
        public double Velocity
        {
            get { return 0.88 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Jupiter.tif", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}

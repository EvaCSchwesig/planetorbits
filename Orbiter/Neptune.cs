using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Neptune : IPlanet
    {
        public double Radius
        {
            get { return 30.06; }
        }
        public double Velocity
        {
            get { return 0.36 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Neptune.tif", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}


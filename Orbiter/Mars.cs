using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Mars : IPlanet
    {
        public double Radius
        {
            get { return 1.52; }
        }
        public double Velocity
        {
            get { return 1.62 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Mars.tif", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}


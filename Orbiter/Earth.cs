using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Earth : IPlanet
    {
        public double Radius
        {
            get { return 1.0; }
        }
        public double Velocity
        {
            get { return 2.0 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Earth.tif", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}

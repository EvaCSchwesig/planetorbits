using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Saturn : IPlanet
    {
        public double Radius
        {
            get { return 9.54; }
        }
        public double Velocity
        {
            get { return 0.65 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Saturn.tif", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}

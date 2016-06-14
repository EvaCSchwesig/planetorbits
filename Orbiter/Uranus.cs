using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Uranus : IPlanet
    {
        public double Radius
        {
            get { return 19.19; }
        }
        public double Velocity
        {
            get { return 0.46 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Uranus.jpg", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}

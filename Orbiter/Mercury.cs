using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Mercury : IPlanet
    {
        public double Radius
        {
            get { return 0.39; }
        }
        public double Velocity
        {
            get { return 3.24 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Mercury.jpg", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}

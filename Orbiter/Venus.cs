using System;
using System.Windows.Media.Imaging;

namespace Orbiter
{
    class Venus : IPlanet
    {
        public double Radius
        {
            get { return 0.72; }
        }
        public double Velocity
        {
            get { return 2.34 * Math.PI; }
        }
        public BitmapImage Texture
        {
            get
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("pack://application:,,,/Textures/Venus.tif", UriKind.RelativeOrAbsolute);
                image.EndInit();
                return image;
            }
        }
    }
}

using System.Windows.Media.Imaging;

namespace Orbiter
{
    interface IPlanet
    {
        double Radius { get; }
        double Velocity { get; }
        BitmapImage Texture { get; }
    }
}

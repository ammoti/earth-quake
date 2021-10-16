using System;
using EarthQuake.Model;

namespace EarthQuake.Application
{
    public static class Calculation
    {
        public static double
        GetHaversinDistance(Coordinate FirstPoint, Coordinate SecondPoint)
        {
            double R = 3959;
            double dLat =
                (SecondPoint.Latitude - FirstPoint.Latitude).ToRadians();
            double dLon =
                (SecondPoint.Longitude - FirstPoint.Longitude).ToRadians();
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(FirstPoint.Latitude.ToRadians()) *
                Math.Cos(SecondPoint.Latitude.ToRadians()) *
                Math.Sin(dLon / 2) *
                Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d;
        }
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}

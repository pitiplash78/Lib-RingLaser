using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RingLaser
{
    public class RingLaserPrediction
    {
        public RingLaserPrediction()
        { }

        public Location SiteLocation = null;
        public double SideLength = 0.0;
        public double Lambda = 0.0;
        public double ScaleFactor = double.NaN;

        // Constant: Earth ratoation speed in rad/s
        public const double EarthRotation = 0.00007272205216643; // [rad/s]
        public const double EarthRotationIERS =  7.292115e-5; // [rad/s]

        public double ScaleFactorSquare()
        {
            double A = SideLength * SideLength;
            double L = 4.0 * SideLength;

            return (4 * A) / (Lambda * L);
        }

        /// <summary>
        /// Calculation of the scale factor of a squared ring.
        /// </summary>
        /// <param name="SideLength">Side length [m].</param>
        /// <param name="Lambda">Wave length of the laser [m].</param>
        /// <returns>Scale factor.</returns>
        public double ScaleFactorSquare(double SideLength, double Lambda)
        {
                      this.SideLength = SideLength;
            this.Lambda = Lambda;
            
            double A = SideLength * SideLength;
            double L = 4.0 * SideLength;

            return (4 * A) / (Lambda * L);
        }

        public double ScaleFactorTriangle()
        {
            double A = Math.Sqrt(3.0) / 4.0 * Math.Pow(SideLength, 2);
            double L = 3.0 * SideLength;

            return (4 * A) / (Lambda * L);
        }

        /// <summary>
        /// Calculation of the scale factor of a triangular ring.
        /// </summary>
        /// <param name="SideLength">Side length [m].</param>
        /// <param name="lambda">Wave length of the laser [m].</param>
        /// <returns>Scale factor.</returns>
        public double ScaleFactorTriangle(double SideLength, double Lambda)
        {
            this.SideLength = SideLength;
            this.Lambda = Lambda;

            double A = Math.Sqrt(3.0) / 4.0 * Math.Pow(SideLength, 2);
            double L = 3.0 * SideLength;

            return (4 * A) / (Lambda * L);
        }

        /// <summary>
        /// Class for location of the station the ring is found.
        /// </summary>
        public class Location
        {
            /// <summary>
            /// Name of the location.
            /// </summary>
            public string Name = null;

            /// <summary>
            /// Longitude in degree [0..360°] of the location.
            /// </summary>
            public double Longitude = 0.0;

            /// <summary>
            /// Latitude in degree [90..-90°] of the location.
            /// </summary>
            public double Latitude = 0.0;

            /// <summary>
            /// Height in meter of the location.
            /// </summary>
            public double Height = 0.0; // [m]

            /// <summary>
            /// Emtpy constructor.
            /// </summary>
            public Location()
            { }

            /// <summary>
            /// Constructor creating a location with given parameters.
            /// </summary>
            /// <param name="Name">Name of the location.</param>
            /// <param name="Longitude">Longitude in [°].</param>
            /// <param name="Latitude">Latitude [°].</param>
            /// <param name="Height">Height [m].</param>
            public Location(string Name, double Longitude, double Latitude, double Height)
            {
                this.Name = Name;
                this.Longitude = Longitude;
                this.Latitude = Latitude;
                this.Height = Height;
            }
        }

        /// <summary>
        /// Enumerator given the Coordinate rotation arround which axis.
        /// </summary>
        public enum RotationAround
        {
            X, Y, Z,
        }

        public Coordinate_Cartesian CoordinateRotation(Coordinate_Cartesian cartesian, double angle, RotationAround rotationAround)
        {
            Coordinate_Cartesian cartesian_ = new Coordinate_Cartesian();

            if (rotationAround == RotationAround.X)
            {
                double alpha = angle;
                cartesian_.X = cartesian.X;
                cartesian_.Y = cartesian.Y * Math.Cos(alpha) - cartesian.Z * Math.Sin(alpha);
                cartesian_.Z = cartesian.Y * Math.Sin(alpha) + cartesian.Z * Math.Cos(alpha);
            }
            else if (rotationAround == RotationAround.Y)
            {
                double beta = angle;
                cartesian_.X = cartesian.X * Math.Cos(beta) + cartesian.Z * Math.Sin(beta);
                cartesian_.Y = cartesian.Y;
                cartesian_.Z = -cartesian.X * Math.Sin(beta) + cartesian.Z * Math.Cos(beta);
            }
            else if (rotationAround == RotationAround.Z)
            {
                double gamma = angle;
                cartesian_.X = cartesian.X * Math.Cos(gamma) + cartesian.Y * Math.Sin(gamma);
                cartesian_.Y = -cartesian.X * Math.Sin(gamma) + cartesian.Y * Math.Cos(gamma);
                cartesian_.Z = cartesian.Z;
            }

            return cartesian_;
        }

        /// <summary>
        /// Class for spherical coordinates (R - length of the vector,Theta - latitude ,Phi - longitude)
        /// </summary>
        public class Coordinate_Sperical
        {
            /// <summary>
            /// Length of the vector.
            /// </summary>
            public double R = 1.0;

            /// <summary>
            /// Angle, corresponding to the latitude.
            /// </summary>
            public double Theta = 0.0;

            /// <summary>
            /// Angle, corresponding to the longitude.
            /// </summary>
            public double Phi = 0.0;

            /// <summary>
            /// Emtpy constructor.
            /// </summary>
            public Coordinate_Sperical()
            { }

            /// <summary>
            /// Constructor creating a instance for spherical coordinate.
            /// </summary>
            /// <param name="R">Length of the vector.</param>
            /// <param name="Theta">Angle, corresponding to the latitude.</param>
            /// <param name="Phi">Angle, corresponding to the longitude.</param>
            public Coordinate_Sperical(double R, double Theta, double Phi)
            {
                this.R = R;
                this.Theta = Theta;

                if (Theta == RAD(0.0) || Theta == RAD(180))
                    Phi = 0.0;

                this.Phi = Phi;
            }
        }

        /// <summary>
        /// Class for cartesian coordinates (X, Y, Z) - normal convention
        /// </summary>
        public class Coordinate_Cartesian
        {
            /// <summary>
            /// X coordinate of the triple.
            /// </summary>
            public double X = 0;

            /// <summary>
            /// Y coordinate of the triple.
            /// </summary>
            public double Y = 0;

            /// <summary>
            /// Z coordinate of the triple.
            /// </summary>
            public double Z = 0;

            /// <summary>
            /// Emtpy constructor.
            /// </summary>
            public Coordinate_Cartesian()
            { }

            /// <summary>
            /// Constructor creating a instance for cartesian coordinate.
            /// </summary>
            /// <param name="X">X coordinate of the triple.</param>
            /// <param name="Y">Y coordinate of the triple.</param>
            /// <param name="Z">Z coordinate of the triple.</param>
            public Coordinate_Cartesian(double X, double Y, double Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
        }

        /// <summary>
        /// Coordinate transformation, from spherical to cartesion. 
        /// </summary>
        /// <param name="spherical">Sperical coordinate: R, Theta: 90°..-90°, Phi: 0°..360°; angles in radians.</param>
        /// <returns>Cartesian coordinate: X,Y,Z.</returns>
        public Coordinate_Cartesian CoordinateTransformation_SphericalToCartesion(Coordinate_Sperical spherical)
        {
            Coordinate_Cartesian cartesian = new Coordinate_Cartesian();

            cartesian.X = spherical.R * Math.Cos(spherical.Theta) * Math.Cos(spherical.Phi);
            cartesian.Y = spherical.R * Math.Cos(spherical.Theta) * Math.Sin(spherical.Phi); ;
            cartesian.Z = spherical.R * Math.Sin(spherical.Theta);

            return cartesian;
        }

        /// <summary>
        ///  Coordinate transformation, from cartesion to spherical.
        /// </summary>
        /// <param name="cartesian">Cartesian coordinate: X,Y,Z.</param>
        /// <returns>Sperical coordinate: R, Theta: 90°..-90°, Phi: 0°..360°; angles in radians.</returns>
        public Coordinate_Sperical CoordinateTransformation_CartesionToSpherical(Coordinate_Cartesian cartesian)
        {
            Coordinate_Sperical spherical = new Coordinate_Sperical();

            spherical.R = Math.Sqrt((cartesian.X * cartesian.X + cartesian.Y * cartesian.Y + cartesian.Z * cartesian.Z));
            spherical.Theta = Math.Asin(cartesian.Z / spherical.R);
            spherical.Phi = Math.Atan2(cartesian.Y, cartesian.X);
            if (spherical.Phi < 0)
                spherical.Phi = 2 * Math.PI + spherical.Phi;
            return spherical;
        }

        /// <summary>
        /// Transformation Degree to Radians.
        /// </summary>
        /// <param name="degree">Value to be converted from Degree to Radians.</param>
        /// <returns>The converted Degree in Radians.</returns>
        public static double RAD(double degree)
        {
            return degree * Math.PI / 180.0;
        }

        /// <summary>
        /// Transformation Radians to Degree.
        /// </summary>
        /// <param name="radian">Value to be converted from Degree to Radians.</param>
        /// <returns>The converted Radians in Degree.</returns>
        public static double DEG(double radian)
        {
            return radian / Math.PI * 180.0;
        }
    }
}

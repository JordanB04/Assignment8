using System;

namespace Geometry.Application.Models.Cylinders
{
    public class CylinderResponse
    {
        public Guid Id { get; set; }
        public double Radius { get; set; }
        public double Height { get; set; }
        public double Volume { get; set; }
        public double SurfaceArea { get; set; }
    }
}

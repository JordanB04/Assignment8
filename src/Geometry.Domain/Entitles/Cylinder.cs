using System;

namespace Geometry.Domain.Entities
{
    /// <summary>
    /// Represents a right circular cylinder.
    /// </summary>
    public class Cylinder
    {
        /// <summary>
        /// Unique identifier of the cylinder.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Radius of the cylinder.
        /// Must be greater than zero.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Height of the cylinder.
        /// Must be greater than zero.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Volume of the cylinder: πr²h
        /// </summary>
        public double Volume => Math.PI * Radius * Radius * Height;

        /// <summary>
        /// Surface area: 2πr(h + r)
        /// </summary>
        public double SurfaceArea => 2 * Math.PI * Radius * (Height + Radius);
    }
}

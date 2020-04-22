using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }

        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }

        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }

        }


        public double SurfaceArea()
        {
            return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
        }
        public double LiteralSurfaceArea()
        {
            return 2 * this.length * this.height + 2 * this.width * this.height;
        }
        public double Volume()
        {
            return this.length * this.width * this.height;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            result.AppendLine($"Lateral Surface Area - {this.LiteralSurfaceArea():F2}");
            result.AppendLine($"Volume - {this.Volume():F2}");
            return result.ToString().TrimEnd();
        }
    }
}

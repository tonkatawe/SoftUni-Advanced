﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int? displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement)
        : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
        : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
        : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }

        public int? Displacement
        {
            get
            {
                return this.displacement;
            }
            set
            {
                this.displacement = value;
            }
        }

        public string Efficiency
        {
            get
            {
                return this.efficiency;
            }
            set
            {
                this.efficiency = value;
            }
        }

        public override string ToString()
        {
            var displMsg = this.Displacement.HasValue ? this.Displacement.ToString() : "n/a";
            var effMsg = String.IsNullOrEmpty(this.Efficiency) ? "n/a" : this.Efficiency;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {displMsg}");
            sb.AppendLine($"    Efficiency: {effMsg}");
            return sb.ToString().TrimEnd();
        }
    }
}

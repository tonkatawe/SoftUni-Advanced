﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo()
        {

        }
        public Cargo(int cargoWeight, string cargoType)
        :this()
        {
            this.CargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }
            set
            {
                this.cargoWeight = value;
            }
        }

        public string CargoType
        {
            get
            {
                return this.cargoType;
            }
            set
            {
                this.cargoType = value;
            }
        }
    }
}

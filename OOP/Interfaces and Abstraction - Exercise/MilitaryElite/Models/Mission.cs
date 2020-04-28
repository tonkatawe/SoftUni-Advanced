using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    //20/100 I will solve it again :)
    public class Mission : IMission
    {
        private string name;
        private string state;

        public Mission(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }

        public string Name
        {
            get => this.name;
            private set { this.name = value; }
        }

        public string State
        {
            get => this.state;
            set
            {
                this.state = value;
            }
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }

        public void CompleteMission() //I have to check this!
        {
        }
    }
}

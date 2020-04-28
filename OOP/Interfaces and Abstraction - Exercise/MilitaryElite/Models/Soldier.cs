using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Soldier : ISoldier
    {
        private string firstName;
        private string lastName;
        private int id;

        public Soldier(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName
        {
            get => this.firstName;
            private set { this.firstName = value; }
        }

        public string LastName
        {
            get => this.lastName;
            private set { this.lastName = value; }
        }
        public int Id
        {
            get => this.id;
            set { this.id = value; }
        }
    }
}

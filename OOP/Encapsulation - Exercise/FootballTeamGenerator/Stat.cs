using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stat

    {
        private int endurance;
        private int sprint;
        private int dribbe;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get => this.endurance;
            private set
            {

            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {

            }
        }
        public int Dribble
        {
            get => this.dribbe;
            private set
            {

            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {

            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {

            }
        }

        public int GetAverage()
        {
            double result = this.Endurance + this.Sprint + this.Passing + this.Dribble + this.Shooting;
            var result2 = (int)Math.Round(result / 5);
            return result2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class LengthInputValidation
    {
        public static bool IsValidToAddTeam(string[] input)
        {
            if (input.Length == 2)
            {
                return true;

            }
            return false;
        }

        public static bool IsValidToAddPlayer(string[] input)
        {
            if (input.Length == 8)
            {
                return true;
            }

            return false;
        }
        public static bool IsValidToRemovePlayer(string[] input)
        {
            if (input.Length == 3)
            {
                return true;
            }

            return false;
        }
    }
}

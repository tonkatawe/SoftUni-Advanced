using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        //I will back to solve this task after 2 weeks today is (27.04.2020)
        public static void Main(string[] args)
        {
            var teams = new List<Team>();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                var tokens = command.Split(';');
                if (LengthInputValidation.IsValidToAddTeam(tokens))
                {
                    var instructions = tokens[0];
                    Team team = new Team(tokens[1]);
                    if (instructions == "team" && !teams.Contains(team))
                    {
                        teams.Add(team);

                    }
                    else if (instructions == "Rating" && !teams.Contains(team))
                    {
                        team.Rating();
                    }

                }
                else if (LengthInputValidation.IsValidToAddPlayer(tokens))
                {
                    var team = new Team(tokens[1]);
                    var playerName = tokens[2];
                    var endurance = int.Parse(tokens[3]);
                    var sprint = int.Parse(tokens[4]);
                    var dribble = int.Parse(tokens[5]);
                    var passing = int.Parse(tokens[6]);
                    var shooting = int.Parse(tokens[7]);
                    var stats = new Stat(endurance, sprint, dribble, passing, shooting);
                    var player = new Player(playerName, stats);
                    if (teams.Contains(team))
                    {
                        team.AddPlayer(player);
                    }


                }
                else if (LengthInputValidation.IsValidToRemovePlayer(tokens))
                {
                    var team = new Team(tokens[1]);
                    var playerName = tokens[2];
                    var endurance = int.Parse(tokens[3]);
                    var sprint = int.Parse(tokens[4]);
                    var dribble = int.Parse(tokens[5]);
                    var passing = int.Parse(tokens[6]);
                    var shooting = int.Parse(tokens[7]);
                    var stats = new Stat(endurance, sprint, dribble, passing, shooting);
                    var player = new Player(playerName, stats);
                    if (teams.Contains(team))
                    {
                        team.RemovePlayer(player);
                    }

                }
            }
        }

    }
}

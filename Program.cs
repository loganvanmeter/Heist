using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Heist
{
    class Program
    {
       
        public class TeamMember
        {
            public string Name {get; set;}
            public int SkillLevel {get; set;}
            public double Courage {get; set;}
        }
        public class Bank{
            public int Difficulty {get; set;}

            public Bank(int difficulty){
                Difficulty = difficulty;
            }
        }
        static void AskName(TeamMember member, List<TeamMember> team){
            Console.WriteLine("Enter your team member's name");
            string NameInput = Console.ReadLine();
            if (NameInput != ""){
            member.Name = NameInput;
            } else if (team.Count == 0){
                AskName(member, team);
            } else {
                member.Name = NameInput;
                Console.WriteLine("You entered a blank name. Moving on to the next part of the heist");
            }
        }
        static void AskSkill(TeamMember member){
            Console.WriteLine("Enter your team member's skill level (must be a whole number greater than 0)");
            string SkillInput = Console.ReadLine();
            bool isNum = int.TryParse(SkillInput, out int skillLevel);
            if (isNum && skillLevel >= 0) {
                member.SkillLevel = skillLevel;
            } else {
                Console.WriteLine("Not a valid number");
                AskSkill(member);
            }
        }

        static void AskCourage(TeamMember member){
            Console.WriteLine("Enter your team member's courage factor (must be between 0.0 and 2.0)");
            string CourageInput = Console.ReadLine();
            bool isNum = double.TryParse(CourageInput, out double courageFactor);
            if(isNum && courageFactor > 0 && courageFactor < 2){
                member.Courage = courageFactor;
            } else {
                Console.WriteLine("Not a valid entry.");
                AskCourage(member);
            }
        }

        static void DisplayTeam(List<TeamMember> team){
             Console.WriteLine("------------------------");
            Console.WriteLine($"Team Summary: {team.Count} members");
            Console.WriteLine("------------------------");
            // Console.WriteLine($"Number of team members: {team.Count}");
            // foreach(TeamMember member in team){
            //     Console.WriteLine($"Name: {member.Name} | Skill Level: {member.SkillLevel} | Courage Factor: {member.Courage}");
            // }
        }
        static void CreateTeam(List<TeamMember> team){
            Console.WriteLine("------------------------");
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Number of team members: {team.Count}");
             Console.WriteLine("------------------------");
            TeamMember Member = new TeamMember();
            AskName(Member, team);
            if (Member.Name.Length > 0){
            AskSkill(Member);
            AskCourage(Member);
            team.Add(Member);
            CreateTeam(team);
            } else {
                DisplayTeam(team);
            }
        }
        

        static int Trails(){
            Console.WriteLine("How many trials would you like to simulate for your heist?");
            string TrialInput = Console.ReadLine();
            bool isNum = int.TryParse(TrialInput, out int numTrials);
            if (isNum && numTrials > 0){
                return numTrials;
            } else {
                Console.WriteLine("Not a valid number");
                return Trails();
            }
        }
        static void RunMultipleHeists(List<TeamMember> team){
            int numTrials = Trails();
            int i = 0;
            while (i < numTrials){
                RunHeist(team);
                i++;
            }
        }
        static void RunHeist(List<TeamMember> team){
            Bank bank = new Bank(100);
            int sumSkill = team.Sum(member => member.SkillLevel);
            int LuckValue = new Random().Next(-10, 10);
            int newDifficulty = bank.Difficulty + LuckValue;
            Console.WriteLine("------------------------");
            Console.WriteLine($"Heist Summary: Team Skill Level - {sumSkill} | Bank Difficulty - {newDifficulty}");
             Console.WriteLine("------------------------");
            if(sumSkill < newDifficulty){
                Console.WriteLine("Your heist failed. Whomp Whomp.");
            } else {
                Console.WriteLine("Your heist succeeded. Make it rain!");
            }
            
        }
        static void Main(string[] args)
        {
            List<TeamMember> MyTeam = new List<TeamMember>();
            CreateTeam(MyTeam);
            RunMultipleHeists(MyTeam);
        }
    }
}
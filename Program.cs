using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Heist
{
    class Program
    {
        public double MinCourage = 0.0;
        public double MaxCourage = 2.0;
        public class TeamMember
        {
            public string Name {get; set;}
            public int SkillLevel {get; set;}
            public double Courage {get; set;}
        }

        static void AskName(TeamMember member){
            Console.WriteLine("Enter your team member's name");
            string NameInput = Console.ReadLine();
            if (NameInput != ""){
            member.Name = NameInput;
            } else {
                AskName(member);
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
        static void CreateTeam(){
            Console.WriteLine("------------------------");
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("------------------------");
            TeamMember Member = new TeamMember();
            AskName(Member);
            AskSkill(Member);
            AskCourage(Member);
            Console.WriteLine($"Name: {Member.Name} | Skill: {Member.SkillLevel} | Courage: {Member.Courage}");
        }
        static void Main(string[] args)
        {
            CreateTeam();
        }
    }
}
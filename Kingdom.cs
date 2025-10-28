using System;

namespace StateApp
{
    public class Kingdom : State
    {
        public string KingName { get; set; }
        public int DynastyYears { get; set; }

        public Kingdom(string name, DateTime foundationDate, int population, string leaderName, 
                      string kingName, int dynastyYears) 
            : base(name, foundationDate, population, leaderName)
        {
            KingName = kingName;
            DynastyYears = dynastyYears;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"=== Королевство ===");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Дата основания: {FoundationDate:dd.MM.yyyy}");
            Console.WriteLine($"Возраст государства: {GetAge()} лет");
            Console.WriteLine($"Численность населения: {Population:N0}");
            Console.WriteLine($"Глава государства: {LeaderName}");
            Console.WriteLine($"Король: {KingName}");
            Console.WriteLine($"Лет правления династии: {DynastyYears}");
            Console.WriteLine();
        }

        public override object Clone()
        {
            Kingdom cloned = (Kingdom)base.Clone();
            cloned.KingName = (string)this.KingName.Clone();
            cloned.Name = (string)this.Name.Clone();
            cloned.LeaderName = (string)this.LeaderName.Clone();
            return cloned;
        }
    }
}


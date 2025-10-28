using System;

namespace StateApp
{
    public class Federation : State
    {
        public int NumberOfStates { get; set; }
        public string FederalLeader { get; set; }

        public Federation(string name, DateTime foundationDate, int population, string leaderName, 
                         int numberOfStates, string federalLeader) 
            : base(name, foundationDate, population, leaderName)
        {
            NumberOfStates = numberOfStates;
            FederalLeader = federalLeader;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"=== Федерация ===");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Дата основания: {FoundationDate:dd.MM.yyyy}");
            Console.WriteLine($"Возраст государства: {GetAge()} лет");
            Console.WriteLine($"Численность населения: {Population:N0}");
            Console.WriteLine($"Глава государства: {LeaderName}");
            Console.WriteLine($"Количество субъектов: {NumberOfStates}");
            Console.WriteLine($"Федеральный лидер: {FederalLeader}");
            Console.WriteLine();
        }

        public override object Clone()
        {
            Federation cloned = (Federation)base.Clone();
            cloned.FederalLeader = (string)this.FederalLeader.Clone();
            cloned.Name = (string)this.Name.Clone();
            cloned.LeaderName = (string)this.LeaderName.Clone();
            return cloned;
        }
    }
}


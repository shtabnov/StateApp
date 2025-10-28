using System;

namespace StateApp
{
    public class Republic : State
    {
        public string President { get; set; }
        public int TermYears { get; set; }

        public Republic(string name, DateTime foundationDate, int population, string leaderName, 
                        string president, int termYears) 
            : base(name, foundationDate, population, leaderName)
        {
            President = president;
            TermYears = termYears;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"=== Республика ===");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Дата основания: {FoundationDate:dd.MM.yyyy}");
            Console.WriteLine($"Возраст государства: {GetAge()} лет");
            Console.WriteLine($"Численность населения: {Population:N0}");
            Console.WriteLine($"Глава государства: {LeaderName}");
            Console.WriteLine($"Президент: {President}");
            Console.WriteLine($"Срок полномочий: {TermYears} лет");
            Console.WriteLine();
        }

        public override object Clone()
        {
            Republic cloned = (Republic)base.Clone();
            cloned.President = (string)this.President.Clone();
            cloned.Name = (string)this.Name.Clone();
            cloned.LeaderName = (string)this.LeaderName.Clone();
            return cloned;
        }
    }
}


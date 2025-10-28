using System;
using System.Collections.Generic;

namespace StateApp
{
    public abstract class State : IComparable<State>, ICloneable
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public int Population { get; set; }
        public string LeaderName { get; set; }

        protected State(string name, DateTime foundationDate, int population, string leaderName)
        {
            Name = name;
            FoundationDate = foundationDate;
            Population = population;
            LeaderName = leaderName;
        }

        public abstract void DisplayInfo();

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - FoundationDate.Year;

            if (FoundationDate.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public int CompareTo(State? other)
        {
            if (other == null) return 1;
            return this.Population.CompareTo(other.Population);
        }

        public static IComparer<State> SortByFoundationDate =>
            Comparer<State>.Create((a, b) => a.FoundationDate.CompareTo(b.FoundationDate));

        public static IComparer<State> SortByLeaderName =>
            Comparer<State>.Create((a, b) => string.Compare(a.LeaderName, b.LeaderName, StringComparison.CurrentCulture));

        public virtual object Clone() => MemberwiseClone();
    }
}
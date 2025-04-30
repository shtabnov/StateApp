using System;
using System.Collections.Generic;

namespace StateApp
{
    public abstract class State : IComparable<State>
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public int Population { get; set; }

        protected State(string name, DateTime foundationDate, int population)
        {
            Name = name;
            FoundationDate = foundationDate;
            Population = population;
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


    }
}
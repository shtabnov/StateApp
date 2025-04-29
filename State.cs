using System;

namespace StateApp
{
    public abstract class State
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }

        protected State(string name, DateTime foundationDate)
        {
            Name = name;
            FoundationDate = foundationDate;
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
    }
}
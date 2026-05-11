using System;
using System.Collections.Generic;

namespace HospitalLibrary
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PolicyNumber { get; set; }
        public string Birthday { get; set; }
        public Gender Gender { get; set; }

        public ServiceType Service { get; set; }
        public DateTime AdmissionDate { get; set; }
        public decimal TreatmentCost { get; set; }

        public Person(string name, string surname, string policyNumber, string birthday, Gender gender)
        {
            Name = name;
            Surname = surname;
            PolicyNumber = policyNumber;
            Birthday = birthday;
            Gender = gender;
        }

        public virtual string[] GetInfo()
        {
            return new string[]
            {
                $"{Surname} {Name}",
                $"Полис: {PolicyNumber}",
                $"Дата рождения: {Birthday}"
            };
        }

        public int CompareTo(Person? other)
        {
            if (other == null) return 1;

            int result = string.Compare(this.Surname, other.Surname, StringComparison.OrdinalIgnoreCase);
            if (result == 0)
            {
                result = string.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
            }
            return result;
        }
    }
}
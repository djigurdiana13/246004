using System;
using System.Globalization;

namespace HospitalLibrary
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PolicyNumber { get; }
        public DateTime Birthday { get; }
        public Gender PatientGender { get; }

        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public ServiceType Service { get; set; }
        public decimal TreatmentCost { get; set; }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthday.Year;
                if (DateTime.Now < Birthday.AddYears(age)) age--;
                return age;
            }
        }

        public Person(string name, string surname, string policyNumber, string birthday, Gender gender)
        {
            Name = name;
            Surname = surname;
            PolicyNumber = policyNumber;
            PatientGender = gender;

            var formats = new[] { "dd.MM.yyyy", "d.M.yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "dd/MM/yyyy" };
            if (!DateTime.TryParseExact(birthday, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bday))
                throw new ArgumentException("Неверный формат даты рождения");
            Birthday = bday;

            AdmissionDate = DateTime.Now;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} {Surname} (Полис: {PolicyNumber})";
            string genderStr = PatientGender == Gender.Male ? "мужской" : "женский";
            info[1] = $"Возраст: {Age}. Пол: {genderStr}. Поступил: {AdmissionDate:d}.";
            return info;
        }
    }
}

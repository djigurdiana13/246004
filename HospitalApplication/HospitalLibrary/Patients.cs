using System;
using System.Collections.Generic;

namespace HospitalLibrary
{
    public class Inpatient : Person
    {
        public string DepartmentName { get; set; }
        public int WardNumber { get; set; }

        public Inpatient(string name, string surname, string policyNumber, string birthday, Gender gender, string department, int ward)
            : base(name, surname, policyNumber, birthday, gender)
        {
            DepartmentName = department;
            WardNumber = ward;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Стационар. Отделение: {DepartmentName}, Палата: {WardNumber}";
            return info;
        }
    }

    public class DayPatient : Person
    {
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }

        public DayPatient(string name, string surname, string policyNumber, string birthday, Gender gender, string arrival, string departure)
            : base(name, surname, policyNumber, birthday, gender)
        {
            ArrivalTime = arrival;
            DepartureTime = departure;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Дневной стационар. Время: {ArrivalTime} - {DepartureTime}";
            return info;
        }
    }

    public class Outpatient : Person
    {
        public string DoctorFullName { get; set; }

        public Outpatient(string name, string surname, string policyNumber, string birthday, Gender gender, string doctor)
            : base(name, surname, policyNumber, birthday, gender)
        {
            DoctorFullName = doctor;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Амбулаторный прием. Врач: {DoctorFullName}";
            return info;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    internal class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int PolicyId { get; set; }
        public readonly ServiceType service;
        public readonly DateTime AdmissionDate;
        public readonly DateTime DischargeDate;

        public Person(string name, string surname, int policyId, ServiceType service, DateTime admissionDate, DateTime dischargeDate    )
        {
            Name = name;
            Surname = surname;
            PolicyId = policyId;
            this.service = service;
            AdmissionDate = admissionDate;
            DischargeDate = dischargeDate;
        }

        public virtual string[] GetInfo()
        { 
            var info = new string[2];
            info[0] = $"{Name} {Surname}";

            string serviceStr;
            if (service == ServiceType.Paid)
                serviceStr = "Paid";
            else
                serviceStr = "Insurance";
            info[1] = $"Admission date: {AdmissionDate:d}. Discharge date: {DischargeDate:d}. Service type: {service}";
            return info;
        }
    }
}

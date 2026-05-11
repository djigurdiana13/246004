using System;
using System.Collections;
using System.Collections.Generic;

namespace HospitalLibrary
{
    public class Department : IEnumerable<Person>
    {
        public string Name { get; set; }
        private List<Person> patients;

        public int PatientsCount => patients.Count;

        public Department(string name, IEnumerable<Person> patientsCollection)
        {
            Name = name;
            patients = new List<Person>();

            foreach (var p in patientsCollection)
            {
                if (!patients.Contains(p))
                {
                    patients.Add(p);
                }
            }
        }

        public IEnumerator<Person> GetEnumerator() => patients.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
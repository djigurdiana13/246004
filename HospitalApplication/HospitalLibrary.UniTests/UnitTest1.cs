using NUnit.Framework;
using HospitalLibrary;
using System.Collections.Generic;
using System;

namespace HospitalLibrary.UnitTests
{
    [TestFixture]
    public class HospitalAssignmentTests
    {
      
        [Test]
        public void Inpatient_Test()
        {
            var p = new Inpatient("Иван", "Иванов", "111", "01.01.1990", Gender.Male, "Терапия", 101);
            var info = p.GetInfo();
            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[2], Does.Contain("Терапия"));
        }

        [Test]
        public void DayPatient_Test()
        {
            var p = new DayPatient("Анна", "Петрова", "222", "15.05.1985", Gender.Female, "08:00", "14:00");
            var info = p.GetInfo();
            Assert.That(info[2], Does.Contain("08:00 - 14:00"));
        }

        [Test]
        public void Outpatient_Test()
        {
            var p = new Outpatient("Сергей", "Сидоров", "333", "20.10.1970", Gender.Male, "Др. Хаус");
            var info = p.GetInfo();
            Assert.That(info[2], Does.Contain("Др. Хаус"));
        }


        [Test]
        public void Patient_IComparable_Sorting_Test()
        {
            var p1 = new Person("Борис", "Иванов", "001", "01.01.2000", Gender.Male);
            var p2 = new Person("Алексей", "Иванов", "002", "01.01.2000", Gender.Male);
            var p3 = new Person("Анна", "Антонова", "003", "01.01.2000", Gender.Female);

            var list = new List<Person> { p1, p2, p3 };
            list.Sort();

            Assert.That(list[0].Surname, Is.EqualTo("Антонова"));
            Assert.That(list[1].Name, Is.EqualTo("Алексей"));
            Assert.That(list[2].Name, Is.EqualTo("Борис"));
        }


        [Test]
        public void PolicyComparer_Test()
        {
            var p1 = new Person("А", "А", "999", "01.01.2000", Gender.Male);
            var p2 = new Person("Б", "Б", "111", "01.01.2000", Gender.Male);

            var comparer = new PolicyComparer();
            var result = comparer.Compare(p1, p2);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void Department_UniquePatients_Test()
        {
            var p1 = new Person("Иван", "Иванов", "111", "01.01.1990", Gender.Male);
            var patients = new List<Person> { p1, p1, p1 };

            var dept = new Department("Кардиология", patients);

            Assert.That(dept.PatientsCount, Is.EqualTo(1));
        }

        [Test]
        public void Department_IEnumerable_Iteration_Test()
        {
            var p1 = new Person("Иван", "Иванов", "111", "01.01.1990", Gender.Male);
            var p2 = new Person("Петр", "Петров", "222", "01.01.1990", Gender.Male);
            var dept = new Department("Хирургия", new List<Person> { p1, p2 });

            var resultList = new List<Person>();
            foreach (var patient in dept)
            {
                resultList.Add(patient);
            }

            Assert.That(resultList.Count, Is.EqualTo(2));
        }
    }
}
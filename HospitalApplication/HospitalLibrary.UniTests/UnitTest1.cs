using NUnit.Framework;
using HospitalLibrary;

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
            Assert.That(info[2], Contains.Substring("Терапия"));
        }

        [Test]
        public void DayPatient_Test()
        {
            var p = new DayPatient("Анна", "Петрова", "222", "15.05.1985", Gender.Female, "08:00", "14:00");
            var info = p.GetInfo();
            Assert.That(info[2], Contains.Substring("08:00 - 14:00"));
        }

        [Test]
        public void Outpatient_Test()
        {
            var p = new Outpatient("Сергей", "Сидоров", "333", "20.10.1970", Gender.Male, "Др. Хаус");
            var info = p.GetInfo();
            Assert.That(info[2], Contains.Substring("Др. Хаус"));
        }
    }
}
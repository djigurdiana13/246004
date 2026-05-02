using NUnit.Framework;
using System;
using HospitalLibrary;

namespace HospitalLibrary.UnitTests
{
    [TestFixture]
    public class PatientUnitTests
    {
        [Test]
        public void ConstructorTest()
        {

            var patient = CreateTestPatient();

            Assert.That(patient.Name, Is.EqualTo("Иван"));
            Assert.That(patient.Surname, Is.EqualTo("Иванов"));
            Assert.That(patient.PolicyNumber, Is.EqualTo("123456789"));


            Assert.That(patient.Birthday.Year, Is.EqualTo(1990));
            Assert.That(patient.Birthday.Month, Is.EqualTo(5));
            Assert.That(patient.Birthday.Day, Is.EqualTo(20));

            Assert.That(patient.PatientGender, Is.EqualTo(Gender.Male));
        }

        [Test]
        public void AgeCalculationTest()
        {
    
            var patient = CreateTestPatient();

            int expectedAge = DateTime.Now.Year - 1990;
            if (DateTime.Now < new DateTime(DateTime.Now.Year, 5, 20)) expectedAge--;

            Assert.That(patient.Age, Is.EqualTo(expectedAge));
        }

        [Test]
        public void GetInfoTest()
        {
          
            var patient = CreateTestPatient();
            var info = patient.GetInfo();

           
            Assert.That(info.Length, Is.EqualTo(2));

      
            Assert.That(info[0], Is.EqualTo("Иван Иванов (Полис: 123456789)"));

            Assert.That(info[1], Contains.Substring("мужской"));
            Assert.That(info[1], Contains.Substring("Возраст:"));
            Assert.That(info[1], Contains.Substring("Поступил:"));
        }

        [Test]
        public void SetTreatmentDetailsTest()
        {

            var patient = CreateTestPatient();
            patient.TreatmentCost = 15500.75m;
            patient.Service = ServiceType.Paid;

            Assert.That(patient.TreatmentCost, Is.EqualTo(15500.75m));
            Assert.That(patient.Service, Is.EqualTo(ServiceType.Paid));
        }

        [Test]
        public void InvalidBirthdayFormat_ThrowsException()
        {
    
            Assert.Throws<ArgumentException>(() =>
                new Person("Имя", "Фамилия", "000", "не-дата", Gender.Male)
            );
        }

        private Person CreateTestPatient()
        {
   
            return new Person("Иван", "Иванов", "123456789", "20.05.1990", Gender.Male);
        }
    }
}
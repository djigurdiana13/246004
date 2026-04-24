using NUnit.Framework;
using HospitalLibrary;

namespace HospitalLibrary.UniTests
{
    [TestFixture]
    public class PersonUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var john = CreateTestPerson();

            Assert.That(john.Name, Is.EqualTo("John"));
            Assert.That(john.Surname, Is.EqualTo("Smith"));
            Assert.That(john.PolicyId, Is.EqualTo(12345)); 

            Assert.That(john.AdmissionDate.ToString("dd.MM.yyyy"), Is.EqualTo("15.07.2003"));
            Assert.That(john.DischargeDate.ToString("dd.MM.yyyy"), Is.EqualTo("15.07.2003"));

            Assert.That(john.service, Is.EqualTo(ServiceType.Paid));
        }

        [Test]
        public void GetInfoTest()
        {
            var john = CreateTestPerson();
            var info = john.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("John Smith"));
            Assert.That(info[1], Does.Contain("Admission date: 15.07.2003"));
            Assert.That(info[1], Does.Contain("Discharge date: 15.07.2003"));
            Assert.That(info[1], Does.Contain("Service type: Paid"));
        }

        private Person CreateTestPerson()
        {
            return new Person
                (
                "John",
                "Smith",
                12345,
                ServiceType.Paid,
                new DateTime(2003, 7, 15),
                new DateTime(2003, 7, 15)
            );
        }
    }
}
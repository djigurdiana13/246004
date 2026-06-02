using System;
using NUnit.Framework;
using PhoneCallLibrary;

namespace PhoneCallLibrary.UnitTests
{
    [TestFixture]
    public class PhoneCallTests
    {
        [Test]
        public void ConstructorTest()
        {
            var call = new PhoneCall(120, 2.5);

            Assert.That(call.Time, Is.EqualTo(120));
            Assert.That(call.Rate, Is.EqualTo(2.5));
        }

        [TestCase(0)]
        [TestCase(-15)]
        public void TimeSet_NegativeOrZeroValue_ArgumentException(int val)
        {
            var call = new PhoneCall(60, 2.0);
            Assert.That(() => call.Time = val, Throws.ArgumentException);
        }

        [TestCase(0.0)]
        [TestCase(-3.5)]
        public void RateSet_NegativeOrZeroValue_ArgumentException(double val)
        {
            var call = new PhoneCall(60, 2.0);
            Assert.That(() => call.Rate = val, Throws.ArgumentException);
        }

        [TestCase(60, 3.0, 3.0)]
        [TestCase(150, 2.0, 5.0)]
        [TestCase(45, 4.0, 3.0)]
        public void CostTest(int time, double rate, double expectedCost)
        {
            var call = new PhoneCall(time, rate);
    
            Assert.That(call.Cost, Is.EqualTo(expectedCost).Within(1e-13));
        }

        [TestCase(135, 2.5, "Разговор: 135 c по 2,5 руб./мин")]
        [TestCase(60, 5.0, "Разговор: 60 c по 5 руб./мин")]
        public void ToStringTest(int time, double rate, string expectedResult)
        {
            var call = new PhoneCall(time, rate);

            string actual = call.ToString().Replace('.', ',');
            string expected = expectedResult.Replace('.', ',');

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(120, 2.5, 120, 2.5, true)]
        [TestCase(120, 2.5, 180, 2.5, false)]
        [TestCase(120, 2.5, 120, 3.0, false)]
        public void Equals_TwoCalls_ExpectedResult(int t1, double r1, int t2, double r2, bool expectedResult)
        {
            var call1 = new PhoneCall(t1, r1);
            var call2 = new PhoneCall(t2, r2);

            Assert.That(call1.Equals(call2), Is.EqualTo(expectedResult));
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var call = new PhoneCall(60, 2.0);
            var dummyObject = new object();

            Assert.That(() => call.Equals(dummyObject), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new PhoneCall(150, 3.14);
            var y = new PhoneCall(150, 3.14);
            var z = new PhoneCall(150, 3.14000000000001); 

            Assert.That(x.GetHashCode(), Is.EqualTo(y.GetHashCode()));
            Assert.That(x.GetHashCode(), Is.Not.EqualTo(z.GetHashCode()));
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new PhoneCall(90, 1.5);
            var y = new PhoneCall(90, 1.5);
            var z = new PhoneCall(60, 1.5);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [Test]
        public void AdditionTest_ValidRates()
        {
            var call1 = new PhoneCall(100, 2.5);
            var call2 = new PhoneCall(50, 2.5);
            var expected = new PhoneCall(150, 2.5);

            Assert.That(call1 + call2, Is.EqualTo(expected));
        }

        [Test]
        public void AdditionTest_DifferentRates_ArgumentException()
        {
            var call1 = new PhoneCall(100, 2.5);
            var call2 = new PhoneCall(50, 3.0);

            Assert.That(() => call1 + call2, Throws.ArgumentException);
        }

        [TestCase(2.0, 60, 2.5, 60, 5.0)]
        [TestCase(0.5, 120, 4.0, 120, 2.0)]
        public void MultiplicationTest(double k, int time, double rate, int resTime, double resRate)
        {
            var call = new PhoneCall(time, rate);
            var expected = new PhoneCall(resTime, resRate);

            Assert.That(call * k, Is.EqualTo(expected));
            Assert.That(k * call, Is.EqualTo(expected));
        }

        [Test]
        public void MultiplicationTest_NegativeOrZeroCoef_ArgumentException()
        {
            var call = new PhoneCall(60, 2.0);

            Assert.That(() => call * 0, Throws.ArgumentException);
            Assert.That(() => call * -1.5, Throws.ArgumentException);
        }
    }
}

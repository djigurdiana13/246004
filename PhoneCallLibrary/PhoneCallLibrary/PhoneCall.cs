using System;

namespace PhoneCallLibrary
{
    public struct PhoneCall
    {

        private const double Epsilon = 1e-13;
        private const int SecondsInMinute = 60;

        private int time;
        private double rate;

        public int Time
        {
            get => time;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длительность разговора должна быть целым положительным числом.");
                time = value;
            }
        }

        public double Rate
        {
            get => rate;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Тариф должен быть положительным числом.");
                rate = value;
            }
        }

        public double Cost
        {
            get => ((double)Time / SecondsInMinute) * Rate;
        }


        public PhoneCall(int time, double rate) : this()
        {
            Time = time;
            Rate = rate;
        }


        public override string ToString()
        {
            return $"Разговор: {Time} c по {Rate} руб./мин";
        }


        public override bool Equals(object obj)
        {
            if (obj is PhoneCall)
            {
                PhoneCall other = (PhoneCall)obj;
                return Time == other.Time && Math.Abs(Rate - other.Rate) < Epsilon;
            }
            throw new ArgumentException("Объект для сравнения не является телефонным разговором.");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int p = 23;
                hash = hash * p + Time.GetHashCode();

                hash = hash * p + Rate.GetHashCode();
                return hash;
            }
        }


        public static bool operator ==(PhoneCall x, PhoneCall y) => x.Equals(y);
        public static bool operator !=(PhoneCall x, PhoneCall y) => !x.Equals(y);


        public static PhoneCall operator +(PhoneCall x, PhoneCall y)
        {
            if (Math.Abs(x.Rate - y.Rate) >= Epsilon)
                throw new ArgumentException("Невозможно сложить разговоры с разными тарифами.");

            return new PhoneCall(x.Time + y.Time, x.Rate);
        }


        public static PhoneCall operator *(PhoneCall phoneCall, double k)
        {
            if (k <= 0)
                throw new ArgumentException("Коэффициент изменения тарифа должен быть положительным.");

            return new PhoneCall(phoneCall.Time, phoneCall.Rate * k);
        }

        public static PhoneCall operator *(double k, PhoneCall phoneCall) => phoneCall * k;
    }
}
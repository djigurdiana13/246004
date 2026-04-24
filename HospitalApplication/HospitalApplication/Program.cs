using System;
using HospitalLibrary;

namespace HospitalApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var patient = new Person(
                name: "John",
                surname: "Smith",
                policyId: 12345,
                service: ServiceType.Paid,
                admissionDate: new DateTime(2003, 7, 15),
                dischargeDate: new DateTime(2003, 7, 15)
            );

            // выводим короткую информацию
            Console.WriteLine("Patient:");
            foreach (var line in patient.GetInfo())
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
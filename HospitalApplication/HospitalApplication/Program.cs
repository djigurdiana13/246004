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
                policyNumber: "12345",     
                birthday: "15.07.2003",    
                gender: Gender.Male
            );

      
            patient.Service = ServiceType.Paid;
            patient.AdmissionDate = new DateTime(2023, 7, 15);
            patient.TreatmentCost = 15000.00m;

            Console.WriteLine("=== Информация о пациенте ===");
            string[] info = patient.GetInfo();
            foreach (var line in info)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
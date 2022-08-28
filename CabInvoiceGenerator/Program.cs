using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to CabInvoiceGenerator!");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM); //creating object of InvoiceGenerator;
            double fare = invoiceGenerator.CalculateFare(2.0, 5);//calling CalculateFare method
            Console.WriteLine($"Fare : {fare}");
            double fare1 = invoiceGenerator.CalculateFare(-5.0, -8);//calling CalculateFaremethod
            Console.WriteLine($"Fare : {fare1}");
            //creating instance of InvoiceGenerator class for Normal ride;
            InvoiceGenerator invoiceGeneratorNormal = new InvoiceGenerator(RideType.NORMAL);
            double Normalfare = invoiceGeneratorNormal.CalculateFare(2.0, 5);//calling CalculateFare method
            Console.WriteLine($"NormalFare : {Normalfare}");
            double MinumfareForNormal = invoiceGeneratorNormal.CalculateFare(0.0, 30);//calling CalculateFare method
            Console.WriteLine($"FareZeroDistance : {MinumfareForNormal}");
            try
            {
                InvoiceGenerator invoiceGeneratorNormal1 = new InvoiceGenerator(RideType.Other);
                double Normalfare1 = invoiceGeneratorNormal.CalculateFare(2.0, 5);//calling CalculateFare method
            }
            catch(CabInvoiceException cabInvoiceException)
            {
                Console.WriteLine("Exception is coming due to "+ cabInvoiceException.Message);
            }
        }
    }
}

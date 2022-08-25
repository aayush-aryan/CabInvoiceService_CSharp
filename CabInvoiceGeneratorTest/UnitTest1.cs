using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        //Testcases for checking CalculateFare() method returning right fare or not for Normal Ride
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //creating instance of InvoiceGenerator class for Normal ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            //calculating fare by calling CalculateFare() method;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            //Asserting Values
            Assert.AreEqual(expected, fare);
        }
        //Testcases for checking CalculateFare() method returning right fare or not for Normal Ride
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareForPremiumRide()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            //calculating fare by calling CalculateFare() method;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            //Asserting Values
            Assert.AreEqual(expected, fare);
        }
    }
}
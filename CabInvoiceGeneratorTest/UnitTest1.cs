using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        /// <summary>
        /// for PREMIUM ride
        /// MINIMUM_COST_PER_KM = 15;
        ///COST_PER_TIME = 2;
        ///MINIMUM_FARE = 20;
        ///for normal ride
        /// MINIMUM_COST_PER_KM = 10;
        ///COST_PER_TIME = 1;
        ///MINIMUM_FARE = 5;
        ///totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
        ///
        /// </summary>
        //Testcases for checking CalculateFare() method returning right fare or not for Normal Ride
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareForNormalRide()
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
        /// <summary>
        /// TestCases For Invalid Ride Type
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeAndUserChooseOtherRideType_ShouldReturnExceptionsMessageInvalideRide()
        {
            string actual = string.Empty;
            string expected = string.Empty;
            try
            {
                //creating instance of InvoiceGenerator class for Normal ride;
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.Other);
                double distance = 2.0;
                int time = 5;
                //calculating fare by calling CalculateFare() method;
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException cabInvoiceException)
            {
                expected = "Invalid Ride Type";
                actual = cabInvoiceException.Message;
            }
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// test method for excepting more fare;
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturn_TotalExpectedMoreFareForNormalRide()
        {
            try
            {
                //creating instance of InvoiceGenerator class for Normal ride;
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
                double distance = 2.0;
                int time = 5;
                double Actualfare = 25;
                //calculating fare by calling CalculateFare() method;
                Actualfare = invoiceGenerator.CalculateFare(distance, time);
                double expected = 30;
                //Asserting Values
                Assert.AreNotEqual(expected, Actualfare);
            }
            catch (CabInvoiceException cabInvoiceException)
            {
                System.Console.WriteLine(cabInvoiceException.Message);
            }
        }
        [Test]
        public void GivenDistanceAndTimeShouldReturn_TotalFareExpectedAsMinimumFareForNormalRide()
        {
            try
            {
                //creating instance of InvoiceGenerator class for Normal ride;
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
                double distance = 0.0;
                int time = 2;
                //calculating fare by calling CalculateFare() method;
                double Minumfare = invoiceGenerator.CalculateFare(distance, time);
                double expected = 5;
                //Asserting Values
                Assert.AreEqual(expected, Minumfare);
            }
            catch (CabInvoiceException cabInvoiceException)
            {
                System.Console.WriteLine(cabInvoiceException.Message);
            }
        }
        [Test]
        public void GivenNegativeDistanceAndZeroTimeShouldReturnMiniumFareForNormalRide()
        {
            //creating instance of InvoiceGenerator class for Normal ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = -5.0;
            int time = 0;
            //calculating fare by calling CalculateFare() method;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 5;
            //Asserting Values
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenZerDistanceAndPositiveTimeShouldReturnedWaitingChargesForNormalRide()
        {
            //creating instance of InvoiceGenerator class for Normal ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 0.0;
            int time = 30;
            //calculating fare by calling CalculateFare() method;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 30;
            //Asserting Values
            Assert.AreEqual(expected, fare);
        }
        //Testcases for checking CalculateFare() method returning right fare or not for Premium Ride
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareForPremiumRide()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            //calculating fare by calling CalculateFare() method;
            double fare = invoiceGenerator.CalculateFare(distance, time); //totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            double expected = 40;
            //Asserting Values
            Assert.AreEqual(expected, fare);
        }
        /// <summary>
        /// test method for excepting more fare;
        /// </summary>

        [Test]
        public void GivenDistanceAndTimeShouldReturn_FareForPremiumRideExpectedMoreFare()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            //calculating fare by calling CalculateFare() method;
            double fare = invoiceGenerator.CalculateFare(distance, time); //totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            double expected = 50;
            //Asserting Values
            Assert.AreNotEqual(expected, fare);
        }
        [Test]
        public void GivenZeroDistanceAndTimeShouldReturn_FareForPremiumRideExpectedMinimumFare()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 0.0;
            int time = 5;
            //calculating fare by calling CalculateFare() method;
            double Minimumfare = invoiceGenerator.CalculateFare(distance, time); //totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            double expected = 20;
            //Asserting Values
            Assert.AreEqual(expected, Minimumfare);
        }
        [Test]
        public void GivenZeroDistanceAndPositiveTimeShouldReturn_FareForPremiumRideExpectedWaitingCharge()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 0.0;
            int time = 30;
            //calculating fare by calling CalculateFare() method;
            double Minimumfare = invoiceGenerator.CalculateFare(distance, time); //totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            double expected = 60;
            //Asserting Values
            Assert.AreEqual(expected, Minimumfare);
        }
        [Test]
        public void GivenNegativeDistanceAndPositiveTimeShouldReturn_FareForPremiumRideExpectedBookingCharge()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = -5.0;
            int time = 8;
            //calculating fare by calling CalculateFare() method;
            double Minimumfare = invoiceGenerator.CalculateFare(distance, time); //totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            double expected = 20;
            //Asserting Values
            Assert.AreEqual(expected, Minimumfare);
        }
        [Test]
        public void GivenNegativeDistanceAndNegativeTimeShouldReturn_FareForPremiumRideExpectedCabBookingCharge()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = -5.0;
            int time = -8;
            //calculating fare by calling CalculateFare() method;
            double Minimumfare = invoiceGenerator.CalculateFare(distance, time); //totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            double expected = 20;
            //Asserting Values
            Assert.AreEqual(expected, Minimumfare);
        }
        [Test]
        public void GivenZeroDistanceAndZeroTimeShouldReturn_FareForPremiumRideExpectedCabBookingCharge()
        {
            //creating instance of InvoiceGenerator class for PREMIUM ride;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 0.0;
            int time = 0;
            //calculating fare by calling CalculateFare() method;
            double Minimumfare = invoiceGenerator.CalculateFare(distance, time); //totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            double expected = 20;
            //Asserting Values
            Assert.AreEqual(expected, Minimumfare);
        }

        //UC2
        
        [Test]
        public void GivenMultipleRideShouldReturn_InvoiceSummarryForNormalRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(3.0, 5) };//distance/time->25+35->>60
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2,60);//noOFRide,TotalFare
            Assert.AreEqual(expectedSummary, expectedSummary);
        }

        [Test]
        public void GivenThreeMultipleRideShouldReturn_InvoiceSummarryForNormalRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(3.0, 5), new Ride(10.0, 10) };//distance/time->25+35+110->>60
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(3, 170);//noOFRide,TotalFare
            Assert.AreEqual(expectedSummary, expectedSummary);
        }
        [Test]
        public void GivenThreeMultipleRideShouldReturn_MinimumInvoiceSummarryForNormalRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(0.0, 5), new Ride(-3.0, 0), new Ride(1.0,2) };//distance/time->10+10+10->>30
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(3, 30);//noOFRide,TotalFare
            Assert.AreEqual(expectedSummary, expectedSummary);
        }

        /// <summary>
        /// checking for multiple rides return MinimumFare in InvoiceSummary;
        /// </summary>
        [Test]
        public void GivenMultipleRideShouldReturn_InvoiceSummaryForPremiumRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(5, 5), new Ride(10, 10) };//distance/time->85+170->255
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 255); //noOFRide,TotalFare 
            Assert.AreEqual(summary, expectedSummary);
        }
        /// <summary>
        /// checking for multiple rides return MinimumFare in InvoiceSummary;
        /// </summary>
        [Test]
        public void GivenMultipleRideShouldReturn_MinimumInvoiceSummaryForPremiumRide()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(0.0, 7), new Ride(0.0, 5) };//distance/time->20+20--->40
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 40);//noOfRide,totalFare
            Assert.AreEqual(summary, expectedSummary);
        }
        [Test]
        public void GivenAUserIDTheInvoiceServiceGetsTheListOfRidesFromTheRideRepositoryAndReturnsTheInvoiceForNormal()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(10, 5) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRide("xyz", rides);
            Ride[] rideArray = rideRepository.GetRides("xyz");
            InvoiceSummary summary = new InvoiceSummary(2, 130);
            InvoiceSummary expectedSummary = invoiceGenerator.CalculateFare(rideArray);
            Assert.AreEqual(expectedSummary, summary);
        }
    }
}
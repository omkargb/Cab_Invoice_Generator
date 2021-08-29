using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class InvoiceTests
    {
        InvoiceGenerator invoiceGenerator = null;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        //TC 1
        public void GivenDistanceAndTime_ShouldReturn_TotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 8.0;
            int time = 12;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            System.Console.WriteLine("\nTotal Fare : "+fare);
            Assert.AreEqual(92, fare, 0.0);
        }

        [Test]
        //TC 2
        public void GivenMultipleRide_ShouldReturn_InvoiceSummary()
        {
            // calculate/print total
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 31.0);
            Assert.AreEqual(expectedSummary, summary);
        }


        [Test]
        //TC 3
        public void GivenMultipleRide_ShouldReturn_EnhancedInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(3, 12), new Ride(0.2, 2) };
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 47.0, 23.5); //numOfRides, total, avg
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(expectedSummary, summary);
        }


        [Test]
        //TC 4
        public void GivenUserId_UsingInvoiceSummary_ShouldReturnsInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 10), new Ride(0.2, 2) };
            invoiceGenerator.AddRides("user1", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("user1");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35, "user1");   //no of rides, total, userid
            Assert.AreEqual(expectedSummary, summary);
        }

    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring1.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        [TestMethod()]
        public void statementTest()
        {
            Customer customer = new Customer("John Smith");
            customer.addRental(new Rental(new Movie("Green Book", Movie.NEW_RELEASE), 7));
            customer.addRental(new Rental(new Movie("Monsters Inc.", Movie.CHILDRENS), 3));
            customer.addRental(new Rental(new Movie("Inside Out", Movie.CHILDRENS), 4));
            customer.addRental(new Rental(new Movie("Titanic", Movie.REGULAR), 1));
            customer.addRental(new Rental(new Movie("Ghost", Movie.NEW_RELEASE), 10));

            string actual = customer.statement();
            string expected = "Rental Record for John Smith\n";
            expected += "\tGreen Book\t21\n";
            expected += "\tMonsters Inc.\t1,5\n";
            expected += "\tInside Out\t3\n";
            expected += "\tTitanic\t2\n";
            expected += "\tGhost\t30\n";
            expected += "Amount owed is 57,5\n";
            expected += "You earned 7 frequent renter points";

            Assert.AreEqual(expected, actual);
        }
    }
}
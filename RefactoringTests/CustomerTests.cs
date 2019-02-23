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
            customer.AddRental(new Rental(new Movie("Green Book", Movie.NEW_RELEASE), 7));
            customer.AddRental(new Rental(new Movie("Monsters Inc.", Movie.CHILDRENS), 3));
            customer.AddRental(new Rental(new Movie("Inside Out", Movie.CHILDRENS), 4));
            customer.AddRental(new Rental(new Movie("Titanic", Movie.REGULAR), 1));
            customer.AddRental(new Rental(new Movie("Ghost", Movie.NEW_RELEASE), 10));
            customer.AddRental(new Rental(new Movie("The Favourite", Movie.NEW_RELEASE), 1));

            string actual = customer.Statement();
            string expected = "Rental Record for John Smith\n";
            expected += "\tGreen Book\t21\n";
            expected += "\tMonsters Inc.\t1,5\n";
            expected += "\tInside Out\t3\n";
            expected += "\tTitanic\t2\n";
            expected += "\tGhost\t30\n";
            expected += "\tThe Favourite\t3\n";
            expected += "Amount owed is 60,5\n";
            expected += "You earned 8 frequent renter points";

            Assert.AreEqual(expected, actual);

            Customer customer2 = new Customer("Bill Graham");
            customer2.AddRental(new Rental(new Movie("A Star is Born", Movie.NEW_RELEASE), 5));
            customer2.AddRental(new Rental(new Movie("The Favourite", Movie.NEW_RELEASE), 1));

            string actual2 = customer2.Statement();
            string expected2 = "Rental Record for Bill Graham\n";
            expected2 += "\tA Star is Born\t15\n";
            expected2 += "\tThe Favourite\t3\n";
            expected2 += "Amount owed is 18\n";
            expected2 += "You earned 3 frequent renter points";

            Assert.AreEqual(expected2, actual2);
        }
    }
}
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

        [TestMethod()]
        public void htmlStatementTest()
        {
            Customer customer = new Customer("John Smith");
            customer.AddRental(new Rental(new Movie("Green Book", Movie.NEW_RELEASE), 7));
            customer.AddRental(new Rental(new Movie("Monsters Inc.", Movie.CHILDRENS), 3));
            customer.AddRental(new Rental(new Movie("Inside Out", Movie.CHILDRENS), 4));
            customer.AddRental(new Rental(new Movie("Titanic", Movie.REGULAR), 1));
            customer.AddRental(new Rental(new Movie("Ghost", Movie.NEW_RELEASE), 10));
            customer.AddRental(new Rental(new Movie("The Favourite", Movie.NEW_RELEASE), 1));

            string actual = customer.htmlStatement();
            string expected = "<H1>Rentals for <EM>John Smith</EM></H1><P>\n";
            expected += "Green Book: 21<BR>\n";
            expected += "Monsters Inc.: 1,5<BR>\n";
            expected += "Inside Out: 3<BR>\n";
            expected += "Titanic: 2<BR>\n";
            expected += "Ghost: 30<BR>\n";
            expected += "The Favourite: 3<BR>\n";
            expected += "<P>You owe <EM>60,5</EM><P>\n";
            expected += "On this rental you earned <EM>8</EM> frequent renter points<P>";

            Assert.AreEqual(expected, actual);

            Customer customer2 = new Customer("Bill Graham");
            customer2.AddRental(new Rental(new Movie("A Star is Born", Movie.NEW_RELEASE), 5));
            customer2.AddRental(new Rental(new Movie("The Favourite", Movie.NEW_RELEASE), 1));

            string actual2 = customer2.htmlStatement();
            string expected2 = "<H1>Rentals for <EM>Bill Graham</EM></H1><P>\n";
            expected2 += "A Star is Born: 15<BR>\n";
            expected2 += "The Favourite: 3<BR>\n";
            expected2 += "<P>You owe <EM>18</EM><P>\n";
            expected2 += "On this rental you earned <EM>3</EM> frequent renter points<P>";

            Assert.AreEqual(expected2, actual2);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring1
{
    public class Customer
    {
        public string name { get;  }
        private IList<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void addRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IList<Rental> rentals = this.rentals;
            string result = $"Rental Record for {name}\n";

            foreach(Rental each in rentals)
            {
                double thisAmount = 0;
                switch (each.movie.priceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.daysRented > 2)
                            thisAmount += (each.daysRented - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.daysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.daysRented > 3)
                            thisAmount += (each.daysRented - 3) * 1.5;
                        break;
                }
                //add frequent renter points
                frequentRenterPoints++;

                //add bonus for a two day new release rental
                if (each.movie.priceCode == Movie.NEW_RELEASE && each.daysRented > 1)
                    frequentRenterPoints++;

                //show figures for this rental
                result += $"\t{each.movie.title}\t{thisAmount.ToString()}\n";
                totalAmount += thisAmount;

            }

            //add footer lines
            result += $"Amount owed is {totalAmount.ToString()}\n";
            result += $"You earned {frequentRenterPoints.ToString()} frequent renter points";

            return result;
        }
    }
}

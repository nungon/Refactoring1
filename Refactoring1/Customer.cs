using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring1
{
    public class Customer
    {
        public string Name { get;  }
        private IList<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.Name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IList<Rental> rentals = this.rentals;
            string result = $"Rental Record for {Name}\n";

            foreach(Rental rental in rentals)
            {
                //add frequent renter points
                frequentRenterPoints++;

                //add bonus for a two day new release rental
                if (rental.Movie.PriceCode == Movie.NEW_RELEASE && rental.DaysRented > 1)
                    frequentRenterPoints++;

                //show figures for this rental
                result += $"\t{rental.Movie.Title}\t{rental.GetCharge().ToString()}\n";
                totalAmount += rental.GetCharge(); ;
                  
            }

            //add footer lines
            result += $"Amount owed is {totalAmount.ToString()}\n";
            result += $"You earned {frequentRenterPoints.ToString()} frequent renter points";

            return result;
        }

    }
}

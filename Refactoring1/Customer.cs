using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring1
{
    public class Customer
    {
        public string Name { get; }
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
            string result = $"Rental Record for {Name}\n";

            foreach (Rental rental in rentals)
                result += $"\t{rental.Movie.Title}\t{rental.Movie.GetCharge(rental.DaysRented).ToString()}\n";

            //add footer lines
            result += $"Amount owed is {GetTotalCharge().ToString()}\n";
            result += $"You earned {GetTotalFrequentRenterPoints().ToString()} frequent renter points";

            return result;
        }

        public string htmlStatement()
        {
            string result = $"<H1>Rentals for <EM>{Name}</EM></H1><P>\n";
            foreach(Rental rental in rentals)
                result += $"{rental.Movie.Title}: {rental.Movie.GetCharge(rental.DaysRented)}<BR>\n";

            result += $"<P>You owe <EM>{GetTotalCharge().ToString()}</EM><P>\n";
            result += $"On this rental you earned <EM>{GetTotalFrequentRenterPoints().ToString()}</EM> frequent renter points<P>";

            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach (Rental rental in rentals)
            {
                result += rental.Movie.GetFrequentRenterPoints(rental.DaysRented);
            }
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (Rental rental in rentals)
            {
                result += rental.Movie.GetCharge(rental.DaysRented);
            }
            return result;
        }
    }
}

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
            IList<Rental> rentals = this.rentals;
            string result = $"Rental Record for {Name}\n";

            foreach (Rental rental in rentals)
                result += $"\t{rental.Movie.Title}\t{rental.GetCharge().ToString()}\n";

            //add footer lines
            result += $"Amount owed is {GetTotalCharge().ToString()}\n";
            result += $"You earned {GetTotalFrequentRenterPoints().ToString()} frequent renter points";

            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach (Rental rental in rentals)
            {
                result += rental.GetFrequentRenterPoints();
            }
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (Rental each in rentals)
            {
                result += each.GetCharge();
            }
            return result;
        }
    }
}

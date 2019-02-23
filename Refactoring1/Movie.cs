using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring1
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public string Title { get; }
        public int PriceCode { get; set; }

        public Movie(string title, int priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }

        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (PriceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }

            return result;
        }


        public int GetFrequentRenterPoints(int daysRented)
        {
            if (PriceCode == NEW_RELEASE && daysRented > 1)
                return 2;
            else
                return 1;
        }
    }
}

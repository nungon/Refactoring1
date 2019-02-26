using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring1
{
    public abstract class Price
    {
        public abstract int getPriceCode();
        public abstract double getCharge(int daysRented);
        public virtual int getFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public class ChildrensPrice : Price
    {
        public override int getPriceCode()
        {
            return Movie.CHILDRENS;
        }

        public override double getCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
    public class NewReleasePrice: Price
    {
        public override int getPriceCode()
        {
            return Movie.NEW_RELEASE;
        }
        public override double getCharge(int daysRented)
        {
            double result = daysRented * 3;
            return result;
        }
        public override int getFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;

        }
    }
    public class RegularPrice: Price
    {
        public override int getPriceCode()
        {
            return Movie.REGULAR;
        }
        public override double getCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;
            return result;
        }
    }
    
}

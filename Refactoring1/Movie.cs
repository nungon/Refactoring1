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
        //private int _priceCode;
        private Price _price;

        public Movie(string title, int priceCode)
        {
            this.Title = title;
            setPriceCode(priceCode);
        }
        public int getPriceCode()
        {
            return _price.getPriceCode();
        }
        public void setPriceCode(int arg)
        {
            switch (arg)
            {
                case REGULAR:
                    _price = new RegularPrice();
                    break;
                case CHILDRENS:
                    _price = new ChildrensPrice();
                    break;
                case NEW_RELEASE:
                    _price = new NewReleasePrice();
                    break;
                default:
                    throw new ArgumentException("Incorrect price code");
            }
        }
               
        public double GetCharge(int daysRented)
        {
            return _price.getCharge(daysRented);
        }


        public int GetFrequentRenterPoints(int daysRented)
        {
            return _price.getFrequentRenterPoints(daysRented);
        }


    }
}

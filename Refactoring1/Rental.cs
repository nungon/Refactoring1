using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring1
{
    public class Rental
    {
        public Movie Movie { get; }
        public int DaysRented { get; }

        public Rental(Movie movie, int daysRented)
        {
            this.Movie = movie;
            this.DaysRented = daysRented;
        }



    }
}

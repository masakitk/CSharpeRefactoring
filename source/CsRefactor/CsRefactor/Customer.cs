using System;
using System.Collections.Generic;

namespace CsRefactor
{
    public class Customer
    {
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Name { get; }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;
            IEnumerable<Rental> rentals = _rentals;
            var result = "Rental Record for " + Name + Environment.NewLine;
            foreach (var rental in rentals)
            {
                var thisAmount = rental.GetCharge();

                //レンタルポイントを加算
                frequentRenterPoints++;
                //新作を2日以上借りた場合はボーナスポイント
                if ((rental.Movie.PriceCode == PriceCodes.NewRelease) &&
                    rental.DaysRented> 1)
                    frequentRenterPoints++;
                //この貸出に関する数値の表示
                result += "\t" + rental.Movie.Title+ "\t" +
                          thisAmount + Environment.NewLine;
                totalAmount += thisAmount;
            }

            result += "Amount owed is " + totalAmount + Environment.NewLine;
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}

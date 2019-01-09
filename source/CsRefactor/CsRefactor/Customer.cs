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
            var frequentRenterPoints = 0;
            IEnumerable<Rental> rentals = _rentals;
            var result = "Rental Record for " + Name + Environment.NewLine;
            foreach (var rental in rentals)
            {
                frequentRenterPoints += rental.GetFrequentRenterPoints();
                //この貸出に関する数値の表示
                result += "\t" + rental.Movie.Title+ "\t" +
                          rental.GetCharge() + Environment.NewLine;
            }

            result += $"Amount owed is {GetTotalAmount()}{Environment.NewLine}";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private double GetTotalAmount()
        {
            double totalAmount = 0;
            foreach (var rental in _rentals)
            {
                totalAmount += rental.GetCharge();
            }
            return totalAmount;
        }
    }
}

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
            IEnumerable<Rental> rentals = _rentals;
            var result = "Rental Record for " + Name + Environment.NewLine;
            foreach (var rental in rentals)
            {
                //この貸出に関する数値の表示
                result += "\t" + rental.Movie.Title+ "\t" +
                          rental.Movie.Price.GetCharge(rental.DaysRented) + Environment.NewLine;
            }

            result += $"Amount owed is {GetTotalAmount()}{Environment.NewLine}";
            result += $"You earned {GetTotalFrequentRenterPoints()} frequent renter points";
            return result;
        }

        public string HtmlStatement()
        {
            var result = "<H1>Renttals for <EM>" + Name + "</EM></H1><P>\n";
            foreach (var rental in _rentals)
            {
                //貸出に関する数値の表示
                result += rental.Movie.Title + ": " + rental.Movie.Price.GetCharge(rental.DaysRented) + "<BR>\n";
            }
            //フッタ
            result += "<P>You owe <EM>" + GetTotalAmount() + "</EM><P>\n";
            result += "On this rental you earned <EM>" + GetTotalFrequentRenterPoints() +
                      "</EM> frequent renter points <P>";
            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            var frequentRenterPoints = 0;
            foreach (var rental in _rentals)
            {
                frequentRenterPoints += rental.Movie.Price.GetFrequentRenterPoints(rental.DaysRented);
            }
            return frequentRenterPoints;
        }

        private double GetTotalAmount()
        {
            double totalAmount = 0;
            foreach (var rental in _rentals)
            {
                totalAmount += rental.Movie.Price.GetCharge(rental.DaysRented);
            }
            return totalAmount;
        }
    }
}

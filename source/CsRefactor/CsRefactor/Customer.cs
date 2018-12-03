using System.Collections.Generic;

namespace CsRefactor
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals;

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string getName()
        {
            return _name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerable<Rental> rentals = _rentals;
            string result = "Rental Record for " + getName() + "\n";
            foreach (var rental in rentals)
            {
                double thisAmount = 0;
                Rental each = rental;

                //一行ごとに金額を計算
                switch (each.getMovie().getPriceCode())
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.getDaysRented() > 2)
                            thisAmount += (each.getDaysRented() - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.getDaysRented() * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.getDaysRented() > 3)
                            thisAmount += (each.getDaysRented() - 3) * 1.5;
                        break;
                }

                //レンタルポイントを加算
                frequentRenterPoints++;
                //新作を2日以上借りた場合はボーナスポイント
                if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE) &&
                    each.getDaysRented() > 1)
                    frequentRenterPoints++;
                //この貸出に関する数値の表示
                result += "\t" + each.getMovie().getTitle() + "\t" +
                          thisAmount + "\n";
                totalAmount += thisAmount;
            }

            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + "frequent renter points";
            return result;
        }
    }
}

﻿using System;
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
                double thisAmount = 0;
                var each = rental;

                //一行ごとに金額を計算
                switch (each.Movie.PriceCode)
                {
                    case PriceCodes.Regular:
                        thisAmount += 2;
                        if (each.DaysRented> 2)
                            thisAmount += (each.DaysRented- 2) * 1.5;
                        break;
                    case PriceCodes.NewRelease:
                        thisAmount += each.DaysRented* 3;
                        break;
                    case PriceCodes.Childrens:
                        thisAmount += 1.5;
                        if (each.DaysRented> 3)
                            thisAmount += (each.DaysRented- 3) * 1.5;
                        break;
                }

                //レンタルポイントを加算
                frequentRenterPoints++;
                //新作を2日以上借りた場合はボーナスポイント
                if ((each.Movie.PriceCode == PriceCodes.NewRelease) &&
                    each.DaysRented> 1)
                    frequentRenterPoints++;
                //この貸出に関する数値の表示
                result += "\t" + each.Movie.Title+ "\t" +
                          thisAmount + Environment.NewLine;
                totalAmount += thisAmount;
            }

            result += "Amount owed is " + totalAmount + Environment.NewLine;
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}

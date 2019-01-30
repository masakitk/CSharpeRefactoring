using System;

namespace CsRefactor
{
    public class Movie
    {
        public Movie(string title, PriceCodes priceCode)
        {
            Title = title;
            PriceCode = priceCode;
            Price = BuildPrice(priceCode);
        }

        public IMoviePrice Price { get; set; }

        private IMoviePrice BuildPrice(PriceCodes priceCode)
        {
            switch (priceCode)
            {
                case PriceCodes.Childrens:
                    return new ChildrensPrice();
                case PriceCodes.NewRelease:
                    return new NewRelaesePrice();
                case PriceCodes.Regular:
                    return new RegularPrice();
                default:
                    throw new ArgumentOutOfRangeException(nameof(priceCode), priceCode, null);
            }
        }

        public string Title { get; }

        public PriceCodes PriceCode { get; }
    }

    internal class RegularPrice : IMoviePrice
    {
        public double GetCharge(int daysRented)
        {
            if (daysRented <= 2) return 2.0;
            return 2.0 + (daysRented - 2) * 1.5;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    internal class NewRelaesePrice : IMoviePrice
    {
        public double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }

    internal class ChildrensPrice : IMoviePrice
    {
        public double GetCharge(int daysRented)
        {
            if (daysRented <= 3) return 1.5;
            return 1.5 + (daysRented - 3) * 1.5;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    public interface IMoviePrice
    {
        double GetCharge(int daysRented);
        int GetFrequentRenterPoints(int daysRented);
    }

    public class MoviePrice : IMoviePrice
    {
        private readonly PriceCodes _priceCode;

        public MoviePrice(PriceCodes priceCode)
        {
            _priceCode = priceCode;
        }

        public double GetCharge(int daysRented)
        {
            double amount = 0;

            //一行ごとに金額を計算
            switch (_priceCode)
            {
                case PriceCodes.Regular:
                    amount += 2;
                    if (daysRented > 2)
                        amount += (daysRented - 2) * 1.5;
                    break;
                case PriceCodes.NewRelease:
                    amount += daysRented * 3;
                    break;
                case PriceCodes.Childrens:
                    amount += 1.5;
                    if (daysRented > 3)
                        amount += (daysRented - 3) * 1.5;
                    break;
            }

            return amount;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            var pointToAdd = 0;
            //レンタルポイントを加算
            pointToAdd++;
            //新作を2日以上借りた場合はボーナスポイント
            if ((_priceCode == PriceCodes.NewRelease) && daysRented > 1)
                pointToAdd++;
            return pointToAdd;
        }
    }

    public enum PriceCodes
    {
        Regular,
        NewRelease,
        Childrens
    }
}

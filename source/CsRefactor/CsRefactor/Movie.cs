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

        public MoviePrice Price { get; set; }

        private MoviePrice BuildPrice(PriceCodes priceCode)
        {
            return new MoviePrice(priceCode);
        }

        public string Title { get; }

        public PriceCodes PriceCode { get; }
    }

    public class MoviePrice
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

namespace CsRefactor
{
    public class Movie
    {
        public Movie(string title, PriceCodes priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public string Title { get; }

        public PriceCodes PriceCode { get; }

        public double GetCharge(Rental rental)
        {
            double amount = 0;

            //一行ごとに金額を計算
            switch (this.PriceCode)
            {
                case PriceCodes.Regular:
                    amount += 2;
                    if (rental.DaysRented > 2)
                        amount += (rental.DaysRented - 2) * 1.5;
                    break;
                case PriceCodes.NewRelease:
                    amount += rental.DaysRented * 3;
                    break;
                case PriceCodes.Childrens:
                    amount += 1.5;
                    if (rental.DaysRented > 3)
                        amount += (rental.DaysRented - 3) * 1.5;
                    break;
            }

            return amount;
        }

        public int GetFrequentRenterPoints(Rental rental)
        {
            var pointToAdd = 0;
            //レンタルポイントを加算
            pointToAdd++;
            //新作を2日以上借りた場合はボーナスポイント
            if ((this.PriceCode == PriceCodes.NewRelease) && rental.DaysRented > 1)
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

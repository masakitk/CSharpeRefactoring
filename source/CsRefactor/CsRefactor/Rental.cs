namespace CsRefactor
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public int DaysRented { get; }

        public Movie Movie { get; }

        public double GetCharge()
        {
            double amount = 0;

            //一行ごとに金額を計算
            switch (Movie.PriceCode)
            {
                case PriceCodes.Regular:
                    amount += 2;
                    if (DaysRented > 2)
                        amount += (DaysRented - 2) * 1.5;
                    break;
                case PriceCodes.NewRelease:
                    amount += DaysRented * 3;
                    break;
                case PriceCodes.Childrens:
                    amount += 1.5;
                    if (DaysRented > 3)
                        amount += (DaysRented - 3) * 1.5;
                    break;
            }

            return amount;
        }

        public int GetFrequentRenterPoints()
        {
            var pointToAdd = 0;
            //レンタルポイントを加算
            pointToAdd++;
            //新作を2日以上借りた場合はボーナスポイント
            if ((Movie.PriceCode == PriceCodes.NewRelease) &&
                DaysRented > 1)
                pointToAdd++;
            return pointToAdd;
        }
    }
}

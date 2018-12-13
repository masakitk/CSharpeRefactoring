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
    }

    public enum PriceCodes
    {
        Regular,
        NewRelease,
        Childrens
    }
}

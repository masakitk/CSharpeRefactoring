namespace CsRefactor
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private string _title;
        private int _priceCode;

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public string getTitle()
        {
            return _title; 
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public void setPriceCode(int value)
        {
            _priceCode = value;
        }
    }
}

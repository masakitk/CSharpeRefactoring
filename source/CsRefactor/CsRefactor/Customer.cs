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
    }
}

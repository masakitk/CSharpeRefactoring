using System;

namespace CsRefactor
{
    class Program
    {
        static void Main(string[] args)
        {
            var もののけ姫 = new Movie("もののけ姫", Movie.REGULAR);
            var アンパンマン = new Movie("アンパンマン", Movie.CHILDRENS);
            var ボヘミアンラプソディ = new Movie("ボヘミアン・ラプソディ", Movie.NEW_RELEASE);

            var オギー = new Customer("オギー");

            オギー.AddRental(new Rental(アンパンマン, 3));
            オギー.AddRental(new Rental(もののけ姫, 7));
            オギー.AddRental(new Rental(ボヘミアンラプソディ, 1));

            Console.WriteLine(オギー.Statement());

            Console.Read();

        }
    }
}

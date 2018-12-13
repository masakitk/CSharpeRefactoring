using CsRefactor;
using NUnit.Framework;

namespace CsRefactorTest
{
    [TestFixture]
    public class CustomerTest
    {
        [Test]
        public void OggieRents3Movies()
        {
            var もののけ姫 = new Movie("もののけ姫", PriceCodes.Regular);
            var アンパンマン = new Movie("アンパンマン", PriceCodes.Childrens);
            var ボヘミアンラプソディ = new Movie("ボヘミアン・ラプソディ", PriceCodes.NewRelease);

            var オギー = new Customer("オギー");

            オギー.AddRental(new Rental(アンパンマン, 3));
            オギー.AddRental(new Rental(もののけ姫, 7));
            オギー.AddRental(new Rental(ボヘミアンラプソディ, 1));

            var expected = @"Rental Record for オギー
	アンパンマン	1.5
	もののけ姫	9.5
	ボヘミアン・ラプソディ	3
Amount owed is 14
You earned 3 frequent renter points";
            Assert.That(オギー.Statement(), Is.EqualTo(expected));

        }
    }
}

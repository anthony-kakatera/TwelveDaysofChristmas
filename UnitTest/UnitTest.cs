namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //running test
            var result = TwelveDaysofChristmas.TwelveDaysofChristmas.generateVerses(3);
            //comparing number of verses generated to the user desired number of verses to be generated
            Assert.That(result.Length, Is.EqualTo(3));
        }
    }
}
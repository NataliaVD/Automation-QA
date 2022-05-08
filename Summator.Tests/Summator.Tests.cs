using NUnit.Framework;

namespace Summator.Tests
{
    public class SummatorTests

    {
       [Test]
       public void TestSumWithTwoPositiveNumbers()
        {
            int result = Summator.Sum(new int[] { 5, 7 });
            Assert.That(result == 12);
        }

        [Test]
        public void TestSumWithOnePositiveNmber()
        {
            int result = Summator.Sum(new int[] { 7 });
            Assert.That(result == 7);
        }

        [Test]
        public void TestSumWithEmptyArray()
        {
            int result = Summator.Sum(new int[] {});
            Assert.That(result == 0);
        }

        [Test]
        public void TestSumWithTwoNegativeNumbers()
        {
            int result = Summator.Sum(new int[] { -1, -2});
            Assert.That(result == -3);
        }
    }
}
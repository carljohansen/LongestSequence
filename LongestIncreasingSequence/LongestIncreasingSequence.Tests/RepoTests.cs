namespace LongestIncreasingSequence.Tests
{
    public class RepoTests
    {
        [Fact]
        public void ParsesIntegerInputString()
        {
            var input = "13499 30345 29165 5316";

            var actual = IntegerRepo.GetInputIntegers(input);

            Assert.Equal(new[] { 13499, 30345, 29165, 5316 }, actual);
        }
    }
}
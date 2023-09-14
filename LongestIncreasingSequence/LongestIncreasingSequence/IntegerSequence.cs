public static class IntegerSequence
{
    public static IEnumerable<int> GetLongestIncreasingSequence(IEnumerable<int> input)
    {
        var bestSoFar = new List<int>();
        var bestLengthSoFar = 0;
        var currSequence = new List<int>();
        var previousNum = Int32.MinValue;

        foreach (var n in input.Concat(new[] { Int32.MinValue })) // The suffix value forces us to close off the last sequence, which might be the longest.
        {
            if (n <= previousNum)
            {
                // TODO: not sure what's expected if the number is repeated.  Assume we stop accumulating.
                var currSequenceLength = currSequence.Count();
                if (currSequenceLength > bestLengthSoFar)
                {
                    bestSoFar.Clear();
                    bestSoFar.AddRange(currSequence);
                    bestLengthSoFar = currSequenceLength;
                }
                currSequence.Clear();
            }
            currSequence.Add(n);
            previousNum = n;
        }

        return bestSoFar;
    }
}
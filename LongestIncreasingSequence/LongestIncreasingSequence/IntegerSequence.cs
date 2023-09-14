namespace CarlJ.SequenceDemo;

public static class IntegerSequence
{
    public static (int startIndex, int endIndex) GetLongestIncreasingSequenceBounds(IEnumerable<int> input)
    {
        // This design is optimized for very large inputs whose longest sequence could be very long.  It keeps track only of indexes
        // and makes no copies of the input, therefore it is very memory efficient.  The downside is that it just gives you the bounds
        // and you will need to make a second iteration to extract the actual sequence.
        int bestSoFarStart = 0, bestSoFarEnd = 0;
        var bestLengthSoFar = 0;
        var currSequenceStart = 0;
        var currPos = 0;
        var previousNum = Int32.MinValue;

        foreach (var n in input.Concat(new[] { Int32.MinValue })) // The suffix value forces us to close off the last sequence, which might be the longest.
        {
            if (n <= previousNum)
            {
                // TODO: not sure what's expected if the number is repeated.  Assume we stop accumulating.
                var currSequenceLength = currPos - currSequenceStart;
                if (currSequenceLength > bestLengthSoFar)
                {
                    bestSoFarStart = currSequenceStart;
                    bestSoFarEnd = currPos - 1;
                    bestLengthSoFar = currSequenceLength;
                }
                currSequenceStart = currPos;
            }
            currPos++;
            previousNum = n;
        }

        return (bestSoFarStart, bestSoFarEnd);
    }

    public static IEnumerable<int> GetLongestIncreasingSequence(IReadOnlyCollection<int> indexedInput)
    {
        // Here we assume a collection.  We can't assume a plain enumerable because we need to know we can iterate over it twice.
        var (startPos, endPos) = GetLongestIncreasingSequenceBounds(indexedInput);
        return indexedInput
                .Skip(startPos)
                .Take(endPos - startPos + 1);
    }
}
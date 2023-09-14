namespace CarlJ.SequenceDemo;

public static class IntegerRepo
{
    public static int[] GetInputIntegers(string rawTextInput) => rawTextInput.Split(' ').Select(s => Convert.ToInt32(s.Trim())).ToArray();
}

namespace RehvidGames.Utilities
{
    using System;

    public enum ComparisonResult
    {
        LessThan = -1,
        EqualTo = 0,
        GreaterThan = 1
    }
    
    public static class ComparisonHelper
    {
        public static ComparisonResult Compare<T>(T value, T other) where T : IComparable<T>
        {
            var comparison = value.CompareTo(other);

            return comparison switch
            {
                < 0 => ComparisonResult.LessThan,
                0 => ComparisonResult.EqualTo,
                _ => ComparisonResult.GreaterThan
            };
        }
    }
}
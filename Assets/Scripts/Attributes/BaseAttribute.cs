namespace RehvidGames.Attributes
{
    using System;
    using UnityEngine;
    using Utilities;

    public abstract class BaseAttribute<T> where T: struct, IComparable<T>
    {
        [SerializeField] private T maxValue;
        [SerializeField] private T currentValue;

        public T MaxValue => maxValue;
        public T CurrentValue => currentValue;

        public void SetCurrentValue(T value)
        {
            currentValue = Clamp(value, default, maxValue);
        }

        public void SetMaxValue(T value)
        {
            maxValue = ComparisonHelper.Compare(value, currentValue) == ComparisonResult.LessThan ? currentValue : value;
        }
        
        private T Clamp(T value, T min, T max)
        {
            var comparisonWithMin = ComparisonHelper.Compare(value, min);
            var comparisonWithMax = ComparisonHelper.Compare(value, max);

            if (comparisonWithMin == ComparisonResult.LessThan) return min;
            return comparisonWithMax == ComparisonResult.GreaterThan ? max : value;
        }
    }
}
using System;
using System.Linq;

namespace AdventCode2020Day9
{
    internal class EncondingErrorExecutor
    {
        private EncodingErrorValidator validator;
        public EncondingErrorExecutor()
        {
            validator = new EncodingErrorValidator();
        }


        internal long CalculateSumMinWithMax(long[] values) 
        {
            return values.Min() + values.Max();
        }

        internal long[] FindSetOfValuesToSumUpToValue(long[] streamOfTotalValues, long value) 
        {
            int windowFirstIndex = 0;
            int windowLastIndex = 1;
            
            long[] windowMatched = null;
            long sumOfCurrentWindow = 0;

            do
            {
                do
                {
                    windowMatched = streamOfTotalValues[windowFirstIndex..windowLastIndex];
                    sumOfCurrentWindow = streamOfTotalValues[windowFirstIndex..windowLastIndex].Sum();
                    windowLastIndex++;
                } while (windowLastIndex <= streamOfTotalValues.Length && sumOfCurrentWindow < value);

                if (sumOfCurrentWindow == value) 
                {
                    return windowMatched;

                }
                sumOfCurrentWindow = 0;
                windowFirstIndex++;
                windowLastIndex = windowFirstIndex + 1;
                windowMatched = null;

            } while (windowLastIndex < streamOfTotalValues.Length);

            return windowMatched;

        }

        internal long? FindError(long[] streamOfTotalValues, int preambleSize)
        {
            int windowFirstIndex = 0;
            int windowLastIndex = preambleSize;
            long? sumOfPairToValidate;
            long[] windowToValidate;

            do 
            {
                sumOfPairToValidate = streamOfTotalValues[windowLastIndex];
                windowToValidate = streamOfTotalValues[windowFirstIndex..windowLastIndex];

                windowFirstIndex++;
                windowLastIndex++;

                if (this.validator.IsValueTheSumOfPairs(windowToValidate, sumOfPairToValidate.Value)) 
                {
                    sumOfPairToValidate = null;
                }

            } while (!sumOfPairToValidate.HasValue && windowLastIndex < streamOfTotalValues.Length);

            return sumOfPairToValidate;
        }
    }
}
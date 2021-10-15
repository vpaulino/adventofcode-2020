using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventCode2020Day9
{
    public class PartTwoTests
    {

        private long[] GetValuesStream()
        {
            return new long[] { 35
,20
,15
,25
,47
,40
,62
,55
,65
,95
,102
,117
,150
,182
,127
,219
,299
,277
,309
,576};
        }

            [Fact]
        public void WhenSetOfValuesExactContainMatchWindowSetIsReturned() 
        {
            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long[] values = new long[] { 30, 20, 50, 27 };
             
            long[] windowMatched = executor.FindSetOfValuesToSumUpToValue(values, 127);

                Assert.Collection<long>(windowMatched, 
                  firstElement => Assert.Equal(firstElement, 30)
                , (secondElement) => Assert.Equal(secondElement, 20)
    
                , (thirdElement) => Assert.Equal(thirdElement, 50)
    
                , (fourthElement) => Assert.Equal(fourthElement, 27));

        }


        [Fact]
        public void WhenSetOfValuesContainsMatchWindowSetIsReturned()
        {
            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long[] values = new long[] { 30, 100, 1, 26 };

            long[] windowMatched = executor.FindSetOfValuesToSumUpToValue(values, 127);

            Assert.Collection<long>(windowMatched,
              firstElement => Assert.Equal(firstElement, 100)
            , (secondElement) => Assert.Equal(secondElement, 1)

            , (thirdElement) => Assert.Equal(thirdElement, 26)

            );

        }

        [Fact]
        public void WhenSetOfValuesFromExerciceExampleContainsMatchWindowSetIsReturned()
        {
            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long[] values = GetValuesStream();

            long[] windowMatched = executor.FindSetOfValuesToSumUpToValue(values, 127);

            Assert.Collection<long>(windowMatched,
              firstElement => Assert.Equal(firstElement, 15)
            , (secondElement) => Assert.Equal(secondElement, 25)

            , (thirdElement) => Assert.Equal(thirdElement, 47)

            , (thirdElement) => Assert.Equal(thirdElement, 40)
            );

        }

        [Fact]
        public void WhenSetIsNotSortedAddingMinAndMaxShouldBeCorrect() {

            EncondingErrorExecutor executor = new EncondingErrorExecutor();
            var result = executor.CalculateSumMinWithMax(new long[] { 15, 25, 47, 40 });
            Assert.Equal(result, 62);
        }

        [Fact]
        public void WhenSetIsFromExerciseCalculateCorrectWeakness() 
        {
            EncondingErrorExecutor executor = new EncondingErrorExecutor();
            long[] setOfData = SampleData.GetExerciceSequenceToValidate();

            long? errorValueFound = executor.FindError(setOfData, 25);
            long[] windowMatched = executor.FindSetOfValuesToSumUpToValue(setOfData, errorValueFound.Value);
            long result = executor.CalculateSumMinWithMax(windowMatched);
            Assert.Equal(76096372, result);

        }


    }
}

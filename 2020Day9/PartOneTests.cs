using System.Linq;
using Xunit;

namespace AdventCode2020Day9
{

    public class PartOneTests
    {
        private static long[] GetPreamble(int start = 1, int count= 25)
        {
            return Enumerable.Range(start, count).Select<int, long>(val => (long)val).ToArray();
        }

        [Fact]
        public void WhenIsValueTheSumOfPairsReceives55ItShouldBeValid()
        {
            long[] input = new long[] { 35
                                ,20
                                ,55 };

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 55);

            Assert.True(result);
            
        }

        [Fact]
        public void WhenIsValueTheSumOfPairsReceivesItShouldBeValid()
        {
            long[] input = new long[] { 35
                                ,20
                                ,55
                                ,55};

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 75);

            Assert.True(result);

        }

        [Fact]
        public void WhenIsValueTheSumOfPairsReceives90ItShouldBeValid()
        {
            long[] input = new long[] { 35
                                ,20
                                ,55
                                ,55};

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 90);

            Assert.True(result);

        }

        [Fact]
        public void WhenIsValueTheSumOfPairsReceives26ItShouldBeValid()
        {
            long[] input = GetPreamble();

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 26);

            Assert.True(result);

        }

    

        [Fact]
        public void WhenIsValueTheSumOfPairsReceives49ItShouldBeValid()
        {
            long[] input = GetPreamble();

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 49);

            Assert.True(result);

        }


        [Fact]
        public void WhenIsValueTheSumOfPairsReceives50ItShouldBeInValid()
        {
            long[] input = GetPreamble();

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 50);

            Assert.False(result);

        }

        [Fact]
        public void WhenIsValueTheSumOfPairsReceives26With45AsLastNumberShouldBeIValid()
        {

            long[] input = GetPreamble(1, 26);

            input[0] = 20;

            input[25] = 45;

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 26);

            Assert.True(result);

        }



        [Fact]
        public void WhenIsValueTheSumOfPairsReceives65ItShouldBeValid()
        {
            long[] input = GetPreamble(1, 26);
            input[0] = 20;
            input[19] = 1;
            input[25] = 45;

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 65);

            Assert.False(result);

        }


        [Fact]
        public void WhenIsValueTheSumOfPairsReceives64And66ShouldBeValid()
        {
            long[] input = GetPreamble(1, 26);
            input[0] = 20;
            input[19] = 1;
            input[25] = 45;

            EncodingErrorValidator algorithm = new EncodingErrorValidator();

            var result = algorithm.IsValueTheSumOfPairs(input, 64);

            Assert.True(result);


            result = algorithm.IsValueTheSumOfPairs(input, 66);

            Assert.True(result);

        }


        [Fact]
        public void WhenFindErrorExecutorReceives127houldBeTheFailNumberInSmallSequence()
        {

            long[] streamOfTotalValues =  new long[] { 35
                                ,20
                                ,127 };//GetValuesStream();
            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long? errorValueFound = executor.FindError(streamOfTotalValues, 2);

            Assert.Equal(127, errorValueFound);
        }

        [Fact]
        public void WhenFindErrorExecutorReceives55ItShouldBeAValidNumber()
        {

            long[] streamOfTotalValues = new long[] { 35
                                ,20
                                ,55 };//GetValuesStream();
            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long? errorValueFound = executor.FindError(streamOfTotalValues, 2);

            Assert.Null(errorValueFound);
        }


        [Fact]
        public void WhenFindErrorExecutorReceives127AsSumOfPairsItShouldBeAFailNumber()
        {

            long[] streamOfTotalValues = GetValuesStream();

            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long? errorValueFound = executor.FindError(streamOfTotalValues, 5);

            Assert.Equal(127, errorValueFound);
        }


        [Fact]
        public void WhenFindErrorExecutorReceivesHugeArrayItShouldFindCorrectValue()
        {
            long[] streamOfTotalValues = SampleData.GetExerciceSequenceToValidate();

            EncondingErrorExecutor executor = new EncondingErrorExecutor();

            long? errorValueFound = executor.FindError(streamOfTotalValues, 25);

            Assert.Equal(556543474, errorValueFound);
        }


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
    }
}
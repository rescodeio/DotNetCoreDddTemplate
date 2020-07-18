using Xunit;

namespace UnitTests
{
    public class JobTest
    {
        /*
        [Theory]
        [InlineData("anna", WhitespacePolicy.DontIgnore, "anna", true)]
        [InlineData("sarah haras", WhitespacePolicy.DontIgnore, "sarah haras", true)]
        [InlineData("roger gregor", WhitespacePolicy.DontIgnore, "rogerg regor", false)]
        [InlineData("walt law", WhitespacePolicy.DontIgnore, "wal tlaw", false)]
        [InlineData("luis resco", WhitespacePolicy.DontIgnore, "ocser siul", false)]
        public void CanReverseNames(string name, WhitespacePolicy whitespacePolicy, string reversed, bool isPalindrome)
        {
            var reverser = new ReverserNameUseCase();
            var expected = new ReverseNameResponse(reversed, isPalindrome);
            var result = reverser.Reverse(name, whitespacePolicy);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("roger gregor", WhitespacePolicy.Ignore, "rogerg regor", true)]
        [InlineData("walt law", WhitespacePolicy.Ignore, "wal tlaw", true)]
        [InlineData("luis resco", WhitespacePolicy.Ignore, "ocser siul", false)]
        public void CanReverseNamesIgnoringSpaces(string name, WhitespacePolicy whitespacePolicy, string reversed, bool isPalindrome)
        {
            var reverser = new ReverserNameUseCase();
            var expected = new ReverseNameResponse(reversed, isPalindrome);
            var result = reverser.Reverse(name, whitespacePolicy);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("r a r", WhitespacePolicy.Ignore, "r a r", true)]
        [InlineData("p o o", WhitespacePolicy.Ignore, "o o p", false)]
        public void MultipleSpaces(string name, WhitespacePolicy whitespacePolicy, string reversed, bool isPalindrome)
        {
            var reverser = new ReverserNameUseCase();
            var expected = new ReverseNameResponse(reversed, isPalindrome);
            var result = reverser.Reverse(name, whitespacePolicy);
            Assert.Equal(expected, result);
        }
        */
    }
}
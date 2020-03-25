using Polynomial.WebApi.Services;
using Xunit;

namespace Polynomial.UnitTests
{
    public class CanonicalFormerTests
    {
        [Theory]
        [InlineData("3+1-2", "2")]
        [InlineData("x+3+1-2", "x+2")]
        public void ToCanonical_ShouldReturnCanonicalForm(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            string result = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, result);
        }
    }
}
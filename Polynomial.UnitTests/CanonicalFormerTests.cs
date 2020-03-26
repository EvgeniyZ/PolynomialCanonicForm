using Polynomial.WebApi.Services;
using Xunit;

namespace Polynomial.UnitTests
{
    public class CanonicalFormerTests
    {
        [Theory]
        [InlineData("3+1+2", "6")]
        [InlineData("x+3+1+2", "x+6")]
        [InlineData("x-4-3+2", "x-5")]
        [InlineData("-x-4-3+2", "-x-5")]
        [InlineData("x+xy+y^2", "x+xy+y^2")]
        [InlineData("10+y^4-y^4", "10")]
        public void ToCanonical_ShouldReturnCanonicalForm(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            string result = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, result);
        }
    }
}